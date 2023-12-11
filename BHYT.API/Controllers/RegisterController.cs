using AutoMapper;
using Azure.Core;
using BHYT.API.Models.DbModels;
using BHYT.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BHYT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly BHYTDbContext _context ;
        private IConfiguration _configuration;
        private readonly IMapper _mapper ;
        public RegisterController(BHYTDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> register(RegisterDTO dto)
        {

            var check = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (check != null)
                return BadRequest("User already exists");
            check = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (check != null)
                return BadRequest("Email already exists for other acount");

            try
            {
                User newUser = new User() {
                    Username = dto.Username,
                    Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                    Email = dto.Email,
                    Guid = new Guid(),
                    StatusId = 1,
                    RoleId = 2,  // default customer , empolyee can't sign up
                   
                };
                // add new user
                await _context.Users.AddAsync(newUser);

                // add new 
                await _context.SaveChangesAsync();


                return Ok("User created successfully!");
            }
            catch (Exception ex)
            {
                return Conflict(new 
                {
                    Message = "can't create new user!"
                });
                throw;
            }
        }
    }
}
