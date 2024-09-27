using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpRewardDto : EntityDto, IMapFrom
    {
        public DateTime OrderDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime ContractDate { get; set; }
        public Guid RewardTypeId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid ContractTypeId { get; set; }
        public int DurationInDays { get; set; }
        public int PercentageOrAmount { get; set; }
        public Guid FinancialIndicatorTypeId { get; set; }
        public string Reason { get; set; }
        public string OrderNumber { get; set; }
        public string ContractNumber { get; set; }
        public ModificationContractTypeDto? ContractType { get; set; }
        public DepartmentDto? Department { get; set; }
        public PersonDto? Employee { get; set; }
        public FinancialIndicatorTypeDto? FinancialIndicatorType { get; set; }
        public RewardTypeDto? RewardType { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpReward, EmpRewardDto>()
                .ForMember(dest => dest.OrderDate, src => src.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.ExecutionDate, src => src.MapFrom(src => src.ExecutionDate))
                .ForMember(dest => dest.ContractDate, src => src.MapFrom(src => src.ContractDate))
                .ForMember(dest => dest.RewardTypeId, src => src.MapFrom(src => src.RewardTypeId))
                .ForMember(dest => dest.DepartmentId, src => src.MapFrom(src => src.OrgDepartmentId))
                .ForMember(dest => dest.DurationInDays, src => src.MapFrom(src => src.DurationInDays))
                .ForMember(dest => dest.PercentageOrAmount, src => src.MapFrom(src => src.PercentageOrAmount))
                .ForMember(dest => dest.FinancialIndicatorTypeId, src => src.MapFrom(src => src.FinancialIndicatorTypeId))
                .ForMember(dest => dest.ContractTypeId, src => src.MapFrom(src => src.ContractTypeId))
                .ForMember(dest => dest.Reason, src => src.MapFrom(src => src.Reason))
                .ForMember(dest => dest.OrderNumber, src => src.MapFrom(src => src.OrderNumber))
                .ForMember(dest => dest.ContractNumber, src => src.MapFrom(src => src.ContractNumber))
                .ForMember(dest => dest.ContractType, src => src.MapFrom(src => src.ContractType))
                .ForMember(dest => dest.Department, src => src.MapFrom(src => src.Department))
                .ForMember(dest => dest.Employee, src => src.MapFrom(src => src.Employee))
                .ForMember(dest => dest.FinancialIndicatorType, src => src.MapFrom(src => src.FinancialIndicatorType))
                .ForMember(dest => dest.RewardType, src => src.MapFrom(src => src.RewardType))
                .ReverseMap();
        }
    }
}