using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Services.Common.Mapping;

namespace hiastHRApi.Service.DTO.Constants
{
    public class CountryDto : ConstantDto, IMapFrom
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Country, CountryDto>().ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                    .ReverseMap();
        }
    }
}