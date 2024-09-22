using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpAssignmentDto : EntityDto, IMapFrom
    {
        public DateTime ContractDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ContractTypeId { get; set; }
        public ModificationContractTypeDto? ContractType { get; set; }
        public string AssignedWork { get; set; }
        public string ContractNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpAssignment, EmpAssignmentDto>()
                .ForMember(dest => dest.ContractDate, src => src.MapFrom(src => src.ContractDate))
                .ForMember(dest => dest.StartDate, src => src.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, src => src.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.ContractTypeId, src => src.MapFrom(src => src.ContractTypeId))
                .ForMember(dest => dest.ContractType, src => src.MapFrom(src => src.ContractType))
                .ForMember(dest => dest.AssignedWork, src => src.MapFrom(src => src.AssignedWork))
                .ForMember(dest => dest.ContractNumber, src => src.MapFrom(src => src.ContractNumber)).ReverseMap();
        }
    }
}