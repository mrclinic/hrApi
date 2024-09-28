using AutoMapper;
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpTrainingCourseDto : EntityDto, IMapFrom
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ContractDate { get; set; }
        public Guid ContractTypeId { get; set; }
        public bool DisplayOnRecordCard { get; set; }
        public string CourseName { get; set; }
        public string CourseSource { get; set; }
        public string ContractNumber { get; set; }
        public ModificationContractTypeDto? ContractType { get; set; }
        public Guid EmployeeId { get; set; }
        public string Note { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpTrainingCourse, EmpTrainingCourseDto>()
                .ForMember(dest => dest.StartDate, src => src.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, src => src.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.ContractDate, src => src.MapFrom(src => src.ContractDate))
                .ForMember(dest => dest.ContractTypeId, src => src.MapFrom(src => src.ContractTypeId))
                .ForMember(dest => dest.DisplayOnRecordCard, src => src.MapFrom(src => src.DisplayOnRecordCard))
                .ForMember(dest => dest.CourseName, src => src.MapFrom(src => src.CourseName))
                .ForMember(dest => dest.CourseSource, src => src.MapFrom(src => src.CourseSource))
                .ForMember(dest => dest.ContractNumber, src => src.MapFrom(src => src.ContractNumber))
                .ForMember(dest => dest.ContractType, src => src.MapFrom(src => src.ContractType))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                .ReverseMap();
        }
    }
}