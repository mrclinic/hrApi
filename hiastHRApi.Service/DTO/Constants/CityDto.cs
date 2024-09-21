using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Services.Common.Mapping;

namespace hiastHRApi.Service.DTO.Constants
{
    public class CityDto : ConstantDto, IMapFrom
    {
        public Guid CountryId { get; set; }

        public CountryDto? Country { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<City, CityDto>()
                    .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CountryId, src => src.MapFrom(src => src.CountryId))
                    .ForMember(dest => dest.Country, src => src.MapFrom(src => src.Country)).ReverseMap();
        }
    }
}