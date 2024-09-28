using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpLanguageDto : EntityDto, IMapFrom
    {
        public Guid LanguageId { get; set; }
        public LanguageDto? Language { get; set; }
        public Guid LanguageLevelId { get; set; }
        public LanguageLevelDto? LanguageLevel { get; set; }
        public bool DisplayOnRecordCard { get; set; }
        public Guid EmployeeId { get; set; }
        public string Note { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpLanguage, EmpLanguageDto>()
                .ForMember(dest => dest.LanguageId, src => src.MapFrom(src => src.LanguageId))
                .ForMember(dest => dest.Language, src => src.MapFrom(src => src.Language))
                .ForMember(dest => dest.LanguageLevelId, src => src.MapFrom(src => src.LanguageLevelId))
                .ForMember(dest => dest.LanguageLevel, src => src.MapFrom(src => src.LanguageLevel))
                .ForMember(dest => dest.DisplayOnRecordCard, src => src.MapFrom(src => src.DisplayOnRecordCard))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                .ReverseMap();
        }
    }
}