using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Shared.Common.Mapping;
using hiastHRApi.Shared.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpRelinquishmentDto : EntityDto, IMapFrom
    {
        public DateTime RelinquishmentDate { get; set; }
        public DateTime ContractDate { get; set; }
        public Guid RelinquishmentReasonId { get; set; }
        public Guid ContractTypeId { get; set; }
        public string ContractNumber { get; set; }
        public string Note { get; set; }
        public Guid EmployeeId { get; set; }
        public ModificationContractTypeDto? ContractType { get; set; }
        public RelinquishmentReasonDto? RelinquishmentReason { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpRelinquishment, EmpRelinquishmentDto>()
                .ForMember(dest => dest.RelinquishmentDate, src => src.MapFrom(src => src.RelinquishmentDate))
                .ForMember(dest => dest.ContractDate, src => src.MapFrom(src => src.ContractDate))
                .ForMember(dest => dest.RelinquishmentReasonId, src => src.MapFrom(src => src.RelinquishmentReasonId))
                .ForMember(dest => dest.ContractTypeId, src => src.MapFrom(src => src.ContractTypeId))
                .ForMember(dest => dest.ContractNumber, src => src.MapFrom(src => src.ContractNumber))
                .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.ContractType, src => src.MapFrom(src => src.ContractType))
                .ForMember(dest => dest.RelinquishmentReason, src => src.MapFrom(src => src.RelinquishmentReason))
                .ReverseMap();
        }
    }
}