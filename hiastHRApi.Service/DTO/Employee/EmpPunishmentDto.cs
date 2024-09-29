using AutoMapper;
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpPunishmentDto : EntityDto, IMapFrom
    {
        public DateTime ExecutionDate { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ContractDate { get; set; }
        public Guid IssuingDepartmentId { get; set; }
        public OrgDepartmentDto? IssuingOrgDepartment { get; set; }
        public int DurationInDays { get; set; }
        public Guid OrderDepartmentId { get; set; }
        public OrgDepartmentDto? OrderOrgDepartment { get; set; }
        public bool IsAppearingInRecordCard { get; set; }
        public Guid ContractTypeId { get; set; }
        public ModificationContractTypeDto? ContractType { get; set; }
        public Guid PunishmentTypeId { get; set; }
        public PunishmentTypeDto? PunishmentType { get; set; }
        public int PercentageOrAmount { get; set; }
        public bool IsPercentage { get; set; }
        public string Reason { get; set; }
        public string OrderContractNumber { get; set; }
        public string ContractNumber { get; set; }
        public Guid EmployeeId { get; set; }
        public string Note { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpPunishment, EmpPunishmentDto>()
                .ForMember(dest => dest.ExecutionDate, src => src.MapFrom(src => src.ExecutionDate))
                .ForMember(dest => dest.OrderDate, src => src.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.ContractDate, src => src.MapFrom(src => src.ContractDate))
                .ForMember(dest => dest.IssuingDepartmentId, src => src.MapFrom(src => src.IssuingOrgDepartmentId))
                .ForMember(dest => dest.DurationInDays, src => src.MapFrom(src => src.DurationInDays))
                .ForMember(dest => dest.OrderDepartmentId, src => src.MapFrom(src => src.OrderOrgDepartmentId))
                .ForMember(dest => dest.IsAppearingInRecordCard, src => src.MapFrom(src => src.IsAppearingInRecordCard))
                .ForMember(dest => dest.ContractTypeId, src => src.MapFrom(src => src.ContractTypeId))
                .ForMember(dest => dest.PunishmentTypeId, src => src.MapFrom(src => src.PunishmentTypeId))
                .ForMember(dest => dest.PercentageOrAmount, src => src.MapFrom(src => src.PercentageOrAmount))
                .ForMember(dest => dest.IsPercentage, src => src.MapFrom(src => src.IsPercentage))
                .ForMember(dest => dest.Reason, src => src.MapFrom(src => src.Reason))
                .ForMember(dest => dest.OrderContractNumber, src => src.MapFrom(src => src.OrderContractNumber))
                .ForMember(dest => dest.ContractNumber, src => src.MapFrom(src => src.ContractNumber))
                .ForMember(dest => dest.IssuingOrgDepartment, src => src.MapFrom(src => src.IssuingOrgDepartment))
                .ForMember(dest => dest.OrderOrgDepartment, src => src.MapFrom(src => src.OrderOrgDepartment))
                .ForMember(dest => dest.ContractType, src => src.MapFrom(src => src.ContractType))
                .ForMember(dest => dest.PunishmentType, src => src.MapFrom(src => src.PunishmentType))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                .ReverseMap();
        }
    }
}