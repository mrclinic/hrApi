using AutoMapper;
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpEmploymentStatusDto : EntityDto, IMapFrom
    {
        public DateTime StartDate { get; set; }
        public DateTime ContractDate { get; set; }
        public Guid StartingTypeId { get; set; }
        public StartingTypeDto? StartingType { get; set; }
        public Guid ContractTypeId { get; set; }
        public ModificationContractTypeDto? ContractType { get; set; }
        public string ContractNumber { get; set; }
        public string Note { get; set; } = null!;
        public Guid EmployeeId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpEmploymentStatus, EmpEmploymentStatusDto>()
                .ForMember(dest => dest.StartDate, src => src.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.ContractDate, src => src.MapFrom(src => src.ContractDate))
                .ForMember(dest => dest.StartingTypeId, src => src.MapFrom(src => src.StartingTypeId))
                .ForMember(dest => dest.StartingType, src => src.MapFrom(src => src.StartingType))
                .ForMember(dest => dest.ContractTypeId, src => src.MapFrom(src => src.ContractTypeId))
                .ForMember(dest => dest.ContractType, src => src.MapFrom(src => src.ContractType))
                .ForMember(dest => dest.ContractNumber, src => src.MapFrom(src => src.ContractNumber))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                .ReverseMap();
        }
    }
}