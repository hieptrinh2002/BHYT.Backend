using Azure.Core;
using BHYT.API.Models.DbModels;
using BHYT.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BHYT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BHYTDbContext _context;
        private readonly IConfiguration _configuration;
        public LoginController(BHYTDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private IEnumerable<Claim> GetClaims(User user)
        {

            var roleName = _context.Roles
                            .Where(r => r.Id == user.RoleId)
                            .Select(r => r.Name)
                            .FirstOrDefault();
            return new List<Claim> {

                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.Role, roleName),
                new Claim(ClaimTypes.Name, user.Username),

            };
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            //ClientIp = HttpContext.Connection.RemoteIpAddress.ToString(),
            try
            {
                if (dto != null && !string.IsNullOrEmpty(dto.Username) && !string.IsNullOrEmpty(dto.Password))
                {
                    var user = _context.Users.SingleOrDefault(u => u.Username == dto.Username);
                    if (user != null)
                    {
                        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);

                        if (isPasswordValid)
                        {
                            var authClaims = GetClaims(user);

                            (string token, DateTime expiration, string tokenId) = GenerateToken(authClaims);
                            string refreshToken = GenerateRefreshToken();

                            // save token and refresh token 
                            var refreshTokenEntity = new RefreshToken
                            {
                                Id = Guid.NewGuid(),
                                AccessTokenId = tokenId,
                                Username = user.Username,
                                Token = refreshToken,
                                IsUsed = false,
                                IsRevoked = false,
                                IssuedAt = DateTime.UtcNow,
                                ExpiredAt = DateTime.UtcNow.AddHours(1)
                            };

                            await _context.RefreshTokens.AddAsync(refreshTokenEntity);
                            await _context.SaveChangesAsync();

                            return Ok(new ApiResponseDTO
                            {
                                Success = true,
                                Message = "Genarate token successfully",
                                Data = new {
                                    Token = token,
                                    IssuedAt = DateTime.UtcNow,
                                    ExpiredAt = expiration,
                                    RefreshToken = refreshToken,
                                }
                            });
                        }
                        return BadRequest("invalid password !");
                    }

                    return NotFound("Invalid credentials");
                }

                return BadRequest("Username, Password are required");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        private (string token, DateTime expire, string tokenId) GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var _TokenExpiryTimeInHour = Convert.ToInt64(_configuration["Jwt:TokenExpiryTimeInHour"]);
            var _TokenExpiryTimeInSecond = Convert.ToInt64(_configuration["Jwt:TokenExpiryTimeInSecond"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                //Expires = DateTime.UtcNow.AddHours(_TokenExpiryTimeInHour),
                Expires = DateTime.UtcNow.AddSeconds(_TokenExpiryTimeInSecond),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return (tokenHandler.WriteToken(token), token.ValidTo, token.Id);
        }
        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);

                return Convert.ToBase64String(random);
            }
        }

        [HttpPost("RenewToken")]
        public async Task<IActionResult> RenewToken(TokenDTO dto)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenValidateParam = new TokenValidationParameters
            {
                //tự cấp token
                ValidateIssuer = false,
                ValidateAudience = false,

                //ký vào token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false //ko kiểm tra token hết hạn
            };

            try
            {
                //check AccessToken valid format
                var tokenVerification = jwtTokenHandler.ValidateToken(dto.AccessToken,tokenValidateParam, out SecurityToken validatedToken);
            
                //Check algorithm
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                    if (!result)//false
                    {
                        return Ok(new ApiResponseDTO
                        {
                            Success = false,
                            Message = "Invalid token"
                        });
                    }
                }

                //Check Accesstoken expired?
                var utcExpireDate = long.Parse(tokenVerification.Claims.FirstOrDefault(e => e.Type == JwtRegisteredClaimNames.Exp).Value);
                var expireDate = ConvertUnixTimeToDateTime(utcExpireDate);
                if (expireDate > DateTime.UtcNow)
                {
                    return Ok(new ApiResponse { Success = false, Message = "Access token has not yet expired" });
                }
                //Check refreshtoken exist in DB
                var storedToken = _context.RefreshTokens.FirstOrDefault(x => x.Token == dto.RefreshToken);
                if (storedToken == null)
                {
                    return Ok(new ApiResponse { Success = false, Message = "Refresh token does not exist" });
                }

                //Check refreshToken is used/revoked?
                if (storedToken.IsUsed)
                    return Ok(new ApiResponse { Success = false, Message = "Refresh token has been used" });

                if (storedToken.IsRevoked)
                    return Ok(new ApiResponse { Success = false, Message = "Refresh token has been revoked" });


                //Check AccesstokenID == AccessTokenId in refresh token
                var jti = tokenVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.AccessTokenId != jti)
                {
                    return Ok(new ApiResponse
                    {
                        Success = false,                            
                        Message = "Token doesn't match"
                    });
                }

                //Update token is used
                storedToken.IsRevoked = true;
                storedToken.IsUsed = true;
                _context.Update(storedToken);
                await _context.SaveChangesAsync();


                var user = await _context.Users.SingleOrDefaultAsync(user => user.Username == storedToken.Username);
                if (user == null)
                {
                    return Ok(new ApiResponse
                    {
                        Success = false,
                        Message = "User not found when renew token !"
                    });
                }    
                (string token, DateTime expiration, string tokenId) = GenerateToken(GetClaims(user));
                string refreshToken = GenerateRefreshToken();

                return Ok(new ApiResponseDTO
                {
                    Success = true,
                    Message = "Genarate token successfully",
                    Data = new
                    {
                        Token = token,
                        IssuedAt = DateTime.UtcNow,
                        ExpiredAt = expiration,
                        RefreshToken = refreshToken,
                    }
                });
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();

            return dateTimeInterval;
        }
    }
}
