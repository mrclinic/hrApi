using AutoMapper;
using hiastHRApi.Domain.Entities.Identity;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Services.DTO.Identity
{
    public class RoleDto : EntityDto, IMapFrom
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int StatusCode { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Role, RoleDto>().ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.StatusCode, src => src.MapFrom(src => src.StatusCode))
                .ForMember(dest => dest.DisplayName, src => src.MapFrom(src => src.DisplayName)).ReverseMap();
        }
    }
}
