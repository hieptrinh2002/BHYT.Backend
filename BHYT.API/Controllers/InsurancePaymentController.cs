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
    public class InsurancePaymentController : ControllerBase
    {
        private readonly BHYTDbContext _context;
        private readonly IMapper _mapper;
        public InsurancePaymentController(BHYTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserInsurancePayment(int id)
        {
            try
            {
                var insurancePayments = await _context.InsurancePayments
                       .Where(payment => payment.CustomerId == id)
                       .ProjectTo<InsurancePaymentDTO>(_mapper.ConfigurationProvider)
                       .ToListAsync();

                if (insurancePayments.Any())
                {
                    return Ok(new
                    {
                        insurancePayments
                    });
                }
                return NotFound(new ApiResponse { Message = "Không tìm thấy yêu cầu thanh toán của khách hàng này" });
            }
            catch (Exception)
            {
                return Conflict(new ApiResponseDTO
                {
                    Message = "Lỗi xảy ra khi lấy yêu câu thanh toán"
                });
            }
        }
    }
}
