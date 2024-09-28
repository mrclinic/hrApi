using AutoMapper;
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpWorkPlaceDto : EntityDto, IMapFrom
    {
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfRelinquishment { get; set; }
        public DateTime DateOfContract { get; set; }
        public Guid ContractTypeId { get; set; }
        public string ContractNumber { get; set; }
        public ModificationContractTypeDto? ContractType { get; set; }
        public Guid EmployeeId { get; set; }
        public string Note { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpWorkPlace, EmpWorkPlaceDto>()
                .ForMember(dest => dest.DateOfStart, src => src.MapFrom(src => src.DateOfStart))
                .ForMember(dest => dest.DateOfRelinquishment, src => src.MapFrom(src => src.DateOfRelinquishment))
                .ForMember(dest => dest.DateOfContract, src => src.MapFrom(src => src.DateOfContract))
                .ForMember(dest => dest.ContractTypeId, src => src.MapFrom(src => src.ContractTypeId))
                .ForMember(dest => dest.ContractNumber, src => src.MapFrom(src => src.ContractNumber))
                .ForMember(dest => dest.ContractType, src => src.MapFrom(src => src.ContractType))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                .ReverseMap();
        }
    }
}