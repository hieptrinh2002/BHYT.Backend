using AutoMapper;
using AutoMapper.QueryableExtensions;
using BHYT.API.Models.DbModels;
using BHYT.API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHYT.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerPolicyController : ControllerBase
    {
        private readonly BHYTDbContext _context;
        private readonly IMapper _mapper;

        public CustomerPolicyController(BHYTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerPolicy(int id)
        {
            try
            {
                var customerPolicy = _context.CustomerPolicies
                 .Where(policy => policy.Id == id)
                 .ProjectTo<CustomerPolicyDTO>(_mapper.ConfigurationProvider)
                 .FirstOrDefault();

                if (customerPolicy != null)
                {
                    return Ok(new
                    {
                        customerPolicy
                    });
                }
                return NotFound(new ApiResponse { Message = "Không tìm thấy chính sách" });
            }
            catch (Exception)
            {
                return Conflict(new ApiResponseDTO
                {
                    Message = "Lỗi xảy ra khi lấy chính sách"
                });
            }
        }
    }
}
