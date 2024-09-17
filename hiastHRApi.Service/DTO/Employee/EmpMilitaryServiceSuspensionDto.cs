using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpMilitaryServiceSuspensionDto : EntityDto, IMapFrom
    {
        public DateTime SuspensionDate { get; set; }

        public DateTime SuspensionContractDate { get; set; }

        public DateTime ReturnToServiceDate { get; set; }

        public DateTime ReturnContractDate { get; set; }

        public string SuspensionContractNumber { get; set; }

        public string ReturnContractNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpMilitaryServiceSuspension, EmpMilitaryServiceSuspensionDto>()
                .ForMember(dest => dest.SuspensionDate, src => src.MapFrom(src => src.SuspensionDate))
                .ForMember(dest => dest.SuspensionContractDate, src => src.MapFrom(src => src.SuspensionContractDate))
                .ForMember(dest => dest.ReturnToServiceDate, src => src.MapFrom(src => src.ReturnToServiceDate))
                .ForMember(dest => dest.ReturnContractDate, src => src.MapFrom(src => src.ReturnContractDate))
                .ForMember(dest => dest.SuspensionContractNumber, src => src.MapFrom(src => src.SuspensionContractNumber))
                .ForMember(dest => dest.ReturnContractNumber, src => src.MapFrom(src => src.ReturnContractNumber))
                .ReverseMap();
        }
    }
}