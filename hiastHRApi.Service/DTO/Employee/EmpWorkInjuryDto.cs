using AutoMapper;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpWorkInjuryDto : EntityDto, IMapFrom
    {
        public DateTime ContractDate { get; set; }

        public decimal DisabilityRatio { get; set; }

        public decimal LumpSumAmount { get; set; }

        public decimal MonthlyAmount { get; set; }

        public string InjuryType { get; set; }

        public string ContractNumber { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Role, RoleDto>().ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
        }
    }
}