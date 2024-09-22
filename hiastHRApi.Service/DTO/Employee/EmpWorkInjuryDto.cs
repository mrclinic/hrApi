using AutoMapper;
using hiastHRApi.Domain.Entities.Employee;
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
            profile.CreateMap<EmpWorkInjury, EmpWorkInjuryDto>()
               .ForMember(dest => dest.ContractDate, src => src.MapFrom(src => src.ContractDate))
               .ForMember(dest => dest.DisabilityRatio, src => src.MapFrom(src => src.DisabilityRatio))
               .ForMember(dest => dest.LumpSumAmount, src => src.MapFrom(src => src.LumpSumAmount))
               .ForMember(dest => dest.MonthlyAmount, src => src.MapFrom(src => src.MonthlyAmount))
               .ForMember(dest => dest.InjuryType, src => src.MapFrom(src => src.InjuryType))
               .ForMember(dest => dest.ContractNumber, src => src.MapFrom(src => src.ContractNumber))
               .ReverseMap();
        }
    }
}