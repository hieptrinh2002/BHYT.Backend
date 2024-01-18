using AutoMapper;
using AutoMapper.QueryableExtensions;
using BHYT.API.Models.DbModels;
using BHYT.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHYT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompensationController : ControllerBase
    {
        private readonly BHYTDbContext _context;
        private readonly IMapper _mapper;

        public CompensationController(BHYTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("request")]
        public async Task<ActionResult<IEnumerable<CompensationDTO>>> GetCompensationRequestByCustomerID(int customerId, bool? status)
            {
            try
            {
                var result = await _context.Compensations
                    .Join(_context.CustomerPolicies, 
                        compensation => compensation.PolicyId, 
                        policy => policy.Id,
                        (compensation, policy) => new { compensation, policy }
                     )
                    .Join(_context.Users,
                        cp => cp.policy.CustomerId,
                        customer => customer.Id,
                        (cp, customer) => new { cp.compensation, cp.policy, customer }
                     )
                    .Where(cp => cp.compensation.Status == status && cp.customer.Id == customerId)
                    .Select(cp => _mapper.Map<CompensationDTO>(cp.compensation)) // Ánh xạ từ Compensation sang CompensationDTO
                    .ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(new ApiResponseDTO
                {
                    Message = "Lấy danh sách yêu cầu thanh toán thất bại !"
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCompensationRequest([FromBody] CompensationDTO compensationDto)
        {
            try
            {
                Compensation temp = new Compensation();
                temp = _mapper.Map<Compensation>(compensationDto);
                _context.Compensations.Add(temp);
                await _context.SaveChangesAsync();
                return Ok(new ApiResponseDTO
                {
                    Success = true,
                    Message= "Yêu cầu thanh toán thành công!"
                });
            }
            catch (Exception ex) {
                return BadRequest(new ApiResponseDTO { Message = "lỗi gửi yêu cầu bồi thưởng!" });
            }   
        }
    }
}
