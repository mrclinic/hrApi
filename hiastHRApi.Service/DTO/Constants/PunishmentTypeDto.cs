using AutoMapper;

using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Services.Common.Mapping;

namespace hiastHRApi.Service.DTO.Constants
{
    public class PunishmentTypeDto : ConstantDto, IMapFrom
    {
        public Guid FinancialImpactId { get; set; }

        public FinancialImpactDto FinancialImpact { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PunishmentType, PunishmentTypeDto>()
                                            .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                                            .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                                            .ForMember(dest => dest.FinancialImpact, src => src.MapFrom(src => src.FinancialImpact))
                                            .ForMember(dest => dest.FinancialImpactId, src => src.MapFrom(src => src.FinancialImpactId))
                                            .ReverseMap();
        }
    }
}