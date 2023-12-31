using AutoMapper;
using BHYT.API.Models.DbModels;
using BHYT.API.Models.DTOs;

namespace BHYT.API.Utilities
{
    public class AutoMapper: Profile
    {
        public AutoMapper() {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<InsurancePayment, InsurancePaymentDTO>().ReverseMap();
            CreateMap<CustomerPolicy, CustomerPolicyDTO>().ReverseMap();
            CreateMap<HealthHistory, HealthHistoryDTO>().ReverseMap();

        }
    }
}
