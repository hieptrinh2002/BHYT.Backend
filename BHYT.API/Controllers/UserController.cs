﻿using BHYT.API.Models.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BHYT.API.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Stripe;

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

        [HttpPost("update-status")]
        public async Task<ActionResult> updateStatus(UpdateUserStatusDTO dto)
        {
            try
            {
                var user = await _context.Users
               .Where(x => x.Id == dto.customerId)
               .FirstOrDefaultAsync();

                if (user == null)
                {
                    return NotFound(new ApiResponseDTO
                    {
                        Message = " không tìm thấy user để cập nhật !"
                    });
                }
                user.StatusId = dto.newStatus;
                _context.SaveChanges();

                return Ok(new ApiResponseDTO { Message = "Cập nhật trạng thái thành công !" });

            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponseDTO
                {
                    Message = " lỗi cập nhật trạng thái user !",
                });
            }
        }



        [HttpGet("customer")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            try
            {
                var listUser = await _context.Users
               .Where(x => x.RoleId == 2)
               .OrderBy(x => x.Id)
               .ToListAsync();

                return Ok(_mapper.Map<List<UserDTO>>(listUser));
            }
            catch (Exception ex) {
                return NotFound(new ApiResponseDTO
                {
                    Message = " lỗi lấy danh sách customer",
                });
            }
           
        }

        [HttpGet("role")]
        public async Task<IActionResult> GetUserRole(string username)
        {
            try
            {
                var userRole = (from user in _context.Users
                                join role in _context.Roles on user.RoleId equals role.Id
                                join account in _context.Accounts on user.AccountId equals account.Id
                                where account.Username == username
                                select role.Name).FirstOrDefault();

                if (userRole != "" || userRole != null)
                {
                    return Ok(new
                    {
                        role = userRole
                    });

                }
                return NotFound(new ApiResponse { Message = "user role can't be found" });
            }
            catch(Exception ex)
            {
                return Conflict(new ApiResponseDTO
                {
                    Message = "user role can't be found"
                });
            }
        }
        [HttpGet("get-user")]
        public async Task<IActionResult> GetUserData(string email)
        {
            try
            {
                var userData = _context.Users.FirstOrDefault(x => x.Email == email);
                if (userData != null)
                {
                    var result = _context.CustomerPolicies.FirstOrDefault(x => x.CustomerId == userData.Id);
                    if (result != null)
                    {
                        return Ok(new ApiResponse { Success = true, Message = "Get Policies Successfully!", Data = result });
                    }
                    return NotFound(new ApiResponse { Success = false, Message = "Not Found Policies" });
                }
                return NotFound(new ApiResponse { Success = false, Message = "Not Found Email!" });

            }
            catch
            {
                return Conflict(new ApiResponseDTO
                {
                    Message = "user role can't be found"
                });
            }
        }

    }


}
