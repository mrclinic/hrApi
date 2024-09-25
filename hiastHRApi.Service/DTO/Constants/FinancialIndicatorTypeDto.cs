using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Services.Common.Mapping;

namespace hiastHRApi.Service.DTO.Constants
{
    public class FinancialIndicatorTypeDto : ConstantDto, IMapFrom
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<FinancialIndicatorType, FinancialIndicatorTypeDto>()
                                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}