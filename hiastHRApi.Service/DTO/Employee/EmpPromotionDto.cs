using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpPromotionDto : EntityDto, IMapFrom
    {
        public DateTime PromotionDate { get; set; }
        public int PromotionDuration { get; set; }
        public Guid EvaluationGradeId { get; set; }
        public EvaluationGradeDto? EvaluationGrade { get; set; }
        public decimal NewSalary { get; set; }
        public decimal BonusAmount { get; set; }
        public Guid PromotionPercentageId { get; set; }
        public PromotionPercentageDto? PromotionPercentage { get; set; }
        public Guid EmployeeId { get; set; }
        public string Note { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpPromotion, EmpPromotionDto>()
                .ForMember(dest => dest.PromotionDate, src => src.MapFrom(src => src.PromotionDate))
                .ForMember(dest => dest.PromotionDuration, src => src.MapFrom(src => src.PromotionDuration))
                .ForMember(dest => dest.EvaluationGradeId, src => src.MapFrom(src => src.EvaluationGradeId))
                .ForMember(dest => dest.EvaluationGrade, src => src.MapFrom(src => src.EvaluationGrade))
                .ForMember(dest => dest.NewSalary, src => src.MapFrom(src => src.NewSalary))
                .ForMember(dest => dest.BonusAmount, src => src.MapFrom(src => src.BonusAmount))
                .ForMember(dest => dest.PromotionPercentageId, src => src.MapFrom(src => src.PromotionPercentageId))
                .ForMember(dest => dest.PromotionPercentage, src => src.MapFrom(src => src.PromotionPercentage))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                .ReverseMap();
        }
    }
}