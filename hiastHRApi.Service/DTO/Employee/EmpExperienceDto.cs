using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpExperienceDto : EntityDto, IMapFrom
    {
        public Guid ExperienceTypeId { get; set; }
        public ExperienceTypeDto? ExperienceType { get; set; }
        public string Source { get; set; }
        public string Duration { get; set; }
        public Guid EmployeeId { get; set; }
        public string Note { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpExperience, EmpExperienceDto>()
                .ForMember(dest => dest.ExperienceTypeId, src => src.MapFrom(src => src.ExperienceTypeId))
                .ForMember(dest => dest.ExperienceType, src => src.MapFrom(src => src.ExperienceType))
                .ForMember(dest => dest.Source, src => src.MapFrom(src => src.Source))
                .ForMember(dest => dest.Duration, src => src.MapFrom(src => src.Duration))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                .ReverseMap();
        }
    }
}