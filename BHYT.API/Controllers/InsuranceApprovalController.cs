using AutoMapper;
using BHYT.API.Models.DbModels;
using BHYT.API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHYT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InsuranceApprovalController : ControllerBase
    {
        private readonly BHYTDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public InsuranceApprovalController(BHYTDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet("list")]
        
        public async Task<ActionResult<IEnumerable<InsurancePolicyApprovalDTO>>> GetAllInsuranceApproval()
        {
            try
            {
                var query = from customerPolicy in _context.CustomerPolicies
                            where customerPolicy.Status == false
                            join customer in _context.Users on customerPolicy.CustomerId equals customer.Id
                            join insurance in _context.Insurances on customerPolicy.InsuranceId equals insurance.Id
                            select new
                            {
                                customer = customer,
                                insurance = insurance,
                                customerPolicy = customerPolicy
                            };

                List<InsurancePolicyApprovalDTO> Result = await query.Select((x) => new InsurancePolicyApprovalDTO
                {
                    PolicyID = x.customerPolicy.Id,
                    CustomerID = x.customer.Id,
                    CustomerName = x.customer.Fullname,
                    CustomerBirthday = x.customer.Birthday.ToString(),
                    CustomerSex = x.customer.Sex == 0 ? "Nữ" : "Nam",
                    CustomerPhone = x.customer.Phone,
                    CustomerEmail = x.customer.Email,
                    CustomerAdrress = x.customer.Address,
                    InsuranceID = x.customerPolicy.InsuranceId,
                    InsuranceName = x.insurance.Name,
                    CreatedDate = x.customerPolicy.CreatedDate.ToString(),
                    PaymentOption = x.customerPolicy.PaymentOption == true ? "Tháng" : "Năm",
                    Status = "chờ duyệt"
                }).ToListAsync();

                return Ok(Result);
            }
            catch (Exception ex)
            {
                return Conflict(new ApiResponseDTO
                {
                    Message = "Lấy danh sách yêu cầu mua bảo hiểm thất bại"
                });
            }
        }
    }
}
