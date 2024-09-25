using AutoMapper;

using hiastHRApi.Domain.Entities.Identity;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Services.DTO.Identity
{
    public class PermissionDto : EntityDto, IMapFrom
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public long Order { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Permission, PermissionDto>()
                .ForMember(dest => dest.DisplayName, src => src.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.NAME))
                .ForMember(dest => dest.Order, src => src.MapFrom(src => src.ORDER)).ReverseMap();
        }
    }
}
