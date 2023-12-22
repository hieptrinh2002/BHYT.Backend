using BHYT.API.Models.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BHYT.API.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace BHYT.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly BHYTDbContext _context;
        private IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserController(BHYTDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var listUser = await _context.Users
                .OrderBy(x => x.Id)
                .ToListAsync();

            return Ok(_mapper.Map<List<UserDTO>>(listUser));
        }

        [HttpGet("role")]
        public async Task<IActionResult> GetUserRole(string username)
        {
            try
            {
                var userRole = (from user in _context.Users
                                join role in _context.Roles on user.Id equals role.Id
                                select role.Name).FirstOrDefault();

                if (userRole != "")
                {
                    return Ok(new
                    {
                        role = userRole
                    });

                }
                return NotFound("user role can't be found");
            }
            catch(Exception ex)
            {
                return Conflict(new
                {
                    Message = "user role can't be found"
                });
            }
        }
    }
}
