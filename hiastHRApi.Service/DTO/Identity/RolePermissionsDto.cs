using AutoMapper;

using hiastHRApi.Domain.Entities.Identity;
using hiastHRApi.Shared.Common.Mapping;
using hiastHRApi.Shared.Common.Models;

namespace hiastHRApi.Services.DTO.Identity
{
    public class RolePermissionsDto : EntityDto, IMapFrom
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public RoleDto? Role { get; set; }
        public PermissionDto? Permission { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RolePermissions, RolePermissionsDto>()
                .ForMember(dest => dest.RoleId, src => src.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.Role, src => src.MapFrom(src => src.Role))
                .ForMember(dest => dest.Permission, src => src.MapFrom(src => src.Permission))
                .ForMember(dest => dest.PermissionId, src => src.MapFrom(src => src.PermissionId)).ReverseMap();
        }
    }
}
