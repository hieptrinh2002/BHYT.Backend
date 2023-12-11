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
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var listUser = await _context.Users
                .OrderBy(x => x.Id)
                .ToListAsync();

            return Ok(_mapper.Map<List<UserDTO>>(listUser));
        }
    }
}
