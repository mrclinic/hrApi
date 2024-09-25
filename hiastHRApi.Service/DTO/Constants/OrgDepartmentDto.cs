using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Shared.Common.Mapping;

namespace hiastHRApi.Service.DTO.Constants
{
    public class OrgDepartmentDto : ConstantDto, IMapFrom
    {
        public Guid? ParentId { get; set; }
        public OrgDepartmentDto? Parent { get; set; }
        public ICollection<OrgDepartmentDto> SubOrgDepartments { get; set; } = new List<OrgDepartmentDto>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrgDepartment, OrgDepartmentDto>()
                     .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                     .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                     .ForMember(dest => dest.ParentId, src => src.MapFrom(src => src.ParentId))
                     .ForMember(dest => dest.Parent, src => src.MapFrom(src => src.Parent))
                     .ForMember(dest => dest.SubOrgDepartments, src => src.MapFrom(src => src.SubOrgDepartments))
                     .ReverseMap();
        }
    }
}
