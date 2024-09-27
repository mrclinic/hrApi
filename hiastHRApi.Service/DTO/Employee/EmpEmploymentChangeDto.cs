using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;
using Sieve.Attributes;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpEmploymentChangeDto : EntityDto, IMapFrom
    {
        public DateTime DateOfAppointmentVisa { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfChange { get; set; }
        public DateTime DateOfContract { get; set; }
        public int Salary { get; set; }
        public int InsuranceSalary { get; set; }
        public Guid JobChangeReasonId { get; set; }
        public JobChangeReasonDto? JobChangeReason { get; set; }
        public Guid ModificationContractTypeId { get; set; }
        public ModificationContractTypeDto? ModificationContractType { get; set; }
        public Guid JobTitleId { get; set; }
        public JobTitleDto? JobTitle { get; set; }
        public string Workplace { get; set; }
        public string VisaNumber { get; set; }
        public string ContractNumber { get; set; }
        public string Note { get; set; } = null!;
        public Guid EmployeeId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpEmploymentChange, EmpEmploymentChangeDto>()
                .ForMember(dest => dest.DateOfAppointmentVisa, src => src.MapFrom(src => src.DateOfAppointmentVisa))
                .ForMember(dest => dest.DateOfStart, src => src.MapFrom(src => src.DateOfStart))
                .ForMember(dest => dest.DateOfChange, src => src.MapFrom(src => src.DateOfChange))
                .ForMember(dest => dest.DateOfContract, src => src.MapFrom(src => src.DateOfContract))
                .ForMember(dest => dest.Salary, src => src.MapFrom(src => src.Salary))
                .ForMember(dest => dest.InsuranceSalary, src => src.MapFrom(src => src.InsuranceSalary))
                .ForMember(dest => dest.JobChangeReasonId, src => src.MapFrom(src => src.JobChangeReasonId))
                .ForMember(dest => dest.JobChangeReason, src => src.MapFrom(src => src.JobChangeReason))
                .ForMember(dest => dest.ModificationContractTypeId, src => src.MapFrom(src => src.ModificationContractTypeId))
                .ForMember(dest => dest.ModificationContractType, src => src.MapFrom(src => src.ModificationContractType))
                .ForMember(dest => dest.JobTitleId, src => src.MapFrom(src => src.JobTitleId))
                .ForMember(dest => dest.JobTitle, src => src.MapFrom(src => src.JobTitle))
                .ForMember(dest => dest.Workplace, src => src.MapFrom(src => src.Workplace))
                .ForMember(dest => dest.VisaNumber, src => src.MapFrom(src => src.VisaNumber))
                .ForMember(dest => dest.ContractNumber, src => src.MapFrom(src => src.ContractNumber))
                .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.EmployeeId))
                .ReverseMap();
        }
    }
}