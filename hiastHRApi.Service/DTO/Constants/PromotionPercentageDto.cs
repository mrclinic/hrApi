﻿using AutoMapper;

using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Services.Common.Mapping;

namespace hiastHRApi.Service.DTO.Constants
{
    public class PromotionPercentageDto : ConstantDto, IMapFrom
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PromotionPercentage, PromotionPercentageDto>()
                                            .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                                            .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}