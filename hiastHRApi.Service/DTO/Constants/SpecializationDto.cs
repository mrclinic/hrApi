using System;
using AutoMapper;

using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Shared.Common.Mapping;

namespace hiastHRApi.Service.DTO.Constants
{
    public class SpecializationDto : ConstantDto, IMapFrom
    {
        public Guid QualificationId { get; set; }

        public QualificationDto? Qualification { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Specialization, SpecializationDto>()
                                            .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                                            .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                                            .ForMember(dest => dest.QualificationId, src => src.MapFrom(src => src.QualificationId))
                                            .ForMember(dest => dest.Qualification, src => src.MapFrom(src => src.Qualification))
                                            .ReverseMap();
        }
    }
}