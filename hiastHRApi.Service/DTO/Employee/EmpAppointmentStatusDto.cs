using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpAppointmentStatusDto : EntityDto, IMapFrom
    {
        public DateTime DateOfAppointmentDecision { get; set; }

        public DateTime DateOfAppointmentVisa { get; set; }

        public DateTime DateOfModifiedAppointmentVisaDate { get; set; }

        public DateTime DateOfInsuranceStart { get; set; }

        public int GeneralRegistryNumber { get; set; }

        public Guid InsuranceSystemId { get; set; }

        public InsuranceSystemDto InsuranceSystem { get; set; }

        public int EngineersSyndicateNumber { get; set; }

        public Guid AppointmentContractTypeId { get; set; }

        public ModificationContractTypeDto AppointmentContractType { get; set; }

        public Guid LawId { get; set; }

        public LawDto Law { get; set; }

        public Guid HealthyStatusId { get; set; }

        public HealthyStatusDto HealthyStatus { get; set; }

        public Guid DisabilityTypeId { get; set; }

        public DisabilityTypeDto DisabilityType { get; set; }

        public Guid JobCategoryId { get; set; }

        public JobCategoryDto JobCategory { get; set; }

        public Guid ModificationContractTypeId { get; set; }

        public ModificationContractTypeDto ModificationContractType { get; set; }

        public Guid StartingTypeId { get; set; }

        public StartingTypeDto StartingType { get; set; }

        public string InsuranceNumber { get; set; }

        public string AppointmenContractNumber { get; set; }

        public string AppointmentContractVisaNumber { get; set; }

        public string ModifiedAppointmentContractNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpAppointmentStatus, EmpAppointmentStatusDto>()
                .ForMember(dest => dest.DateOfAppointmentDecision, src => src.MapFrom(src => src.DateOfAppointmentDecision))
                .ForMember(dest => dest.DateOfAppointmentVisa, src => src.MapFrom(src => src.DateOfAppointmentVisa))
                .ForMember(dest => dest.DateOfModifiedAppointmentVisaDate, src => src.MapFrom(src => src.DateOfModifiedAppointmentVisaDate))
                .ForMember(dest => dest.DateOfInsuranceStart, src => src.MapFrom(src => src.DateOfInsuranceStart))
                .ForMember(dest => dest.GeneralRegistryNumber, src => src.MapFrom(src => src.GeneralRegistryNumber))
                .ForMember(dest => dest.InsuranceSystemId, src => src.MapFrom(src => src.InsuranceSystemId))
                .ForMember(dest => dest.InsuranceSystem, src => src.MapFrom(src => src.InsuranceSystem))
                .ForMember(dest => dest.EngineersSyndicateNumber, src => src.MapFrom(src => src.EngineersSyndicateNumber))
                .ForMember(dest => dest.AppointmentContractTypeId, src => src.MapFrom(src => src.AppointmentContractTypeId))
                .ForMember(dest => dest.AppointmentContractType, src => src.MapFrom(src => src.AppointmentContractType))
                .ForMember(dest => dest.LawId, src => src.MapFrom(src => src.LawId))
                .ForMember(dest => dest.Law, src => src.MapFrom(src => src.Law))
                .ForMember(dest => dest.HealthyStatusId, src => src.MapFrom(src => src.HealthyStatusId))
                .ForMember(dest => dest.HealthyStatus, src => src.MapFrom(src => src.HealthyStatus))
                .ForMember(dest => dest.DisabilityTypeId, src => src.MapFrom(src => src.DisabilityTypeId))
                .ForMember(dest => dest.DisabilityType, src => src.MapFrom(src => src.DisabilityType))
                .ForMember(dest => dest.JobCategoryId, src => src.MapFrom(src => src.JobCategoryId))
                .ForMember(dest => dest.JobCategory, src => src.MapFrom(src => src.JobCategory))
                .ForMember(dest => dest.ModificationContractTypeId, src => src.MapFrom(src => src.ModificationContractTypeId))
                .ForMember(dest => dest.ModificationContractType, src => src.MapFrom(src => src.ModificationContractType))
                .ForMember(dest => dest.StartingTypeId, src => src.MapFrom(src => src.StartingTypeId))
                .ForMember(dest => dest.StartingType, src => src.MapFrom(src => src.StartingType))
                .ForMember(dest => dest.InsuranceNumber, src => src.MapFrom(src => src.InsuranceNumber))
                .ForMember(dest => dest.AppointmenContractNumber, src => src.MapFrom(src => src.AppointmenContractNumber))
                .ForMember(dest => dest.AppointmentContractVisaNumber, src => src.MapFrom(src => src.AppointmentContractVisaNumber))
                .ForMember(dest => dest.ModifiedAppointmentContractNumber, src => src.MapFrom(src => src.ModifiedAppointmentContractNumber)).ReverseMap();
        }
    }
}