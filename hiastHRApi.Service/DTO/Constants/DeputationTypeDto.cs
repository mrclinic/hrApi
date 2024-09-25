using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Shared.Common.Mapping;

namespace hiastHRApi.Service.DTO.Constants
{
    public class DeputationTypeDto : ConstantDto, IMapFrom
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeputationType, DeputationTypeDto>()
                     .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                     .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}