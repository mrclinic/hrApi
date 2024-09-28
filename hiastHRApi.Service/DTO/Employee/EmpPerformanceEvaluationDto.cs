using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpPerformanceEvaluationDto : EntityDto, IMapFrom
    {
        public DateTime ReportDate { get; set; }
        public DateTime PromotionDate { get; set; }
        public Guid EvaluationGradeId { get; set; }
        public EvaluationGradeDto? EvaluationGrade { get; set; }
        public Guid EvaluationQuarterId { get; set; }
        public EvaluationQuarterDto? EvaluationQuarter { get; set; }
        public string ReportNumber { get; set; }
        public Guid EmployeeId { get; set; }
        public string Note { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpPerformanceEvaluation, EmpPerformanceEvaluationDto>()
                .ForMember(dest => dest.ReportDate, src => src.MapFrom(src => src.ReportDate))
                .ForMember(dest => dest.PromotionDate, src => src.MapFrom(src => src.PromotionDate))
                .ForMember(dest => dest.EvaluationGradeId, src => src.MapFrom(src => src.EvaluationGradeId))
                .ForMember(dest => dest.EvaluationGrade, src => src.MapFrom(src => src.EvaluationGrade))
                .ForMember(dest => dest.EvaluationQuarterId, src => src.MapFrom(src => src.EvaluationQuarterId))
                .ForMember(dest => dest.EvaluationQuarter, src => src.MapFrom(src => src.EvaluationQuarter))
                .ForMember(dest => dest.ReportNumber, src => src.MapFrom(src => src.ReportNumber))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                .ReverseMap();
        }
    }
}