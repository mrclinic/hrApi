using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Shared.Common.Mapping;
using hiastHRApi.Shared.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpMilitaryServiceDto : EntityDto, IMapFrom
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid MilitaryRankId { get; set; }
        public MilitaryRankDto? MilitaryRank { get; set; }
        public Guid MilitarySpecializationId { get; set; }
        public MilitarySpecializationDto? MilitarySpecialization { get; set; }
        public string MilitaryNumber { get; set; }
        public string ReserveNumber { get; set; }
        public string CohortNumber { get; set; }
        public string RecruitmentBranch { get; set; }
        public string RecruitmentNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpMilitaryService, EmpMilitaryServiceDto>()
                .ForMember(dest => dest.StartDate, src => src.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, src => src.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.MilitaryRankId, src => src.MapFrom(src => src.MilitaryRankId))
                .ForMember(dest => dest.MilitaryRank, src => src.MapFrom(src => src.MilitaryRank))
                .ForMember(dest => dest.MilitarySpecializationId, src => src.MapFrom(src => src.MilitarySpecializationId))
                .ForMember(dest => dest.MilitarySpecialization, src => src.MapFrom(src => src.MilitarySpecialization))
                .ForMember(dest => dest.MilitaryNumber, src => src.MapFrom(src => src.MilitaryNumber))
                .ForMember(dest => dest.ReserveNumber, src => src.MapFrom(src => src.ReserveNumber))
                .ForMember(dest => dest.CohortNumber, src => src.MapFrom(src => src.CohortNumber))
                .ForMember(dest => dest.RecruitmentBranch, src => src.MapFrom(src => src.RecruitmentBranch))
                .ForMember(dest => dest.RecruitmentNumber, src => src.MapFrom(src => src.RecruitmentNumber))
                .ReverseMap();
        }
    }
}