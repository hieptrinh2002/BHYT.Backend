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
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CustomerPolicyController(BHYTDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerPolicy(int id)
        {
            try
            {
                var customerPolicy = await _context.CustomerPolicies
                 .Where(policy => policy.Id == id)
                 .ProjectTo<CustomerPolicyDTO>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

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

        [HttpDelete("reject")]
        public async Task<ActionResult> RejectInsurancePolicy(int policyId)
        {
            CustomerPolicy customerPolicy;
            try
            {
                customerPolicy = _context.CustomerPolicies.Where(x => x.Id == policyId).FirstOrDefault();
                if (customerPolicy == null)
                {
                    return Conflict(new ApiResponseDTO
                    {
                        Message = "Chính sách không tồn tại trong hệ thống !"
                    });

                }
                //_context.CustomerPolicies.Remove(customerPolicy);
                customerPolicy.Status = true;
                await _context.SaveChangesAsync();

                return Ok(new ApiResponseDTO
                {
                    Message = "Xoá chính sách thành công !"
                });
            }
            catch
            {
                return Conflict(new ApiResponseDTO
                {
                    Message = "Lỗi xoá thông tin chính sách!"
                });
            }
            finally
            {
                customerPolicy = null;
            }
        }
    }
}
