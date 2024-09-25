using AutoMapper;

using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Shared.Common.Mapping;

namespace hiastHRApi.Service.DTO.Constants
{
    public class OccurrencePartnerTypeDto : ConstantDto, IMapFrom
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<OccurrencePartnerType, OccurrencePartnerTypeDto>()
                                             .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                                             .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}