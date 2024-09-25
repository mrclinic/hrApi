using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Shared.Common.Mapping;
using hiastHRApi.Shared.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpVacationDto : EntityDto, IMapFrom
    {
        public DateTime StartDate { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ModificationContractDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public int DurationInDays { get; set; }
        public Guid VacationTypeId { get; set; }
        public int VacationYear { get; set; }
        public Guid ContractTypeId { get; set; }
        public bool IsAppearingInRecordCard { get; set; }
        public Guid FinancialImpactId { get; set; }
        public Guid ForcedVacationTypeId { get; set; }
        public bool IsIncludedInServiceDuration { get; set; }
        public Guid ModificationContractTypeId { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string ContractNumber { get; set; }
        public string ModificationContractNumber { get; set; }
        public ModificationContractTypeDto? ContractType { get; set; }
        public PersonDto? Employee { get; set; }
        public FinancialImpactDto? FinancialImpact { get; set; }
        public ForcedVacationTypeDto? ForcedVacationType { get; set; }
        public ModificationContractTypeDto? ModificationContractType { get; set; }
        public VacationTypeDto? VacationType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpVacation, EmpVacationDto>()
                .ForMember(dest => dest.StartDate, src => src.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.ContractDate, src => src.MapFrom(src => src.ContractDate))
                .ForMember(dest => dest.EndDate, src => src.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.ModificationContractDate, src => src.MapFrom(src => src.ModificationContractDate))
                .ForMember(dest => dest.ActualReturnDate, src => src.MapFrom(src => src.ActualReturnDate))
                .ForMember(dest => dest.DurationInDays, src => src.MapFrom(src => src.DurationInDays))
                .ForMember(dest => dest.VacationTypeId, src => src.MapFrom(src => src.VacationTypeId))
                .ForMember(dest => dest.VacationYear, src => src.MapFrom(src => src.VacationYear))
                .ForMember(dest => dest.ContractTypeId, src => src.MapFrom(src => src.ContractTypeId))
                .ForMember(dest => dest.IsAppearingInRecordCard, src => src.MapFrom(src => src.IsAppearingInRecordCard))
                .ForMember(dest => dest.FinancialImpactId, src => src.MapFrom(src => src.FinancialImpactId))
                .ForMember(dest => dest.ForcedVacationTypeId, src => src.MapFrom(src => src.ForcedVacationTypeId))
                .ForMember(dest => dest.IsIncludedInServiceDuration, src => src.MapFrom(src => src.IsIncludedInServiceDuration))
                .ForMember(dest => dest.ModificationContractTypeId, src => src.MapFrom(src => src.ModificationContractTypeId))
                .ForMember(dest => dest.Day, src => src.MapFrom(src => src.Day))
                .ForMember(dest => dest.Month, src => src.MapFrom(src => src.Month))
                .ForMember(dest => dest.Year, src => src.MapFrom(src => src.Year))
                .ForMember(dest => dest.ContractNumber, src => src.MapFrom(src => src.ContractNumber))
                .ForMember(dest => dest.ModificationContractNumber, src => src.MapFrom(src => src.ModificationContractNumber))
                .ForMember(dest => dest.ContractType, src => src.MapFrom(src => src.ContractType))
                .ForMember(dest => dest.Employee, src => src.MapFrom(src => src.Employee))
                .ForMember(dest => dest.FinancialImpact, src => src.MapFrom(src => src.FinancialImpact))
                .ForMember(dest => dest.ForcedVacationType, src => src.MapFrom(src => src.ForcedVacationType))
                .ForMember(dest => dest.ModificationContractType, src => src.MapFrom(src => src.ModificationContractType))
                .ForMember(dest => dest.VacationType, src => src.MapFrom(src => src.VacationType))
                .ReverseMap();
        }
    }
}