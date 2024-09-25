using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Services.Common.Mapping;

namespace hiastHRApi.Service.DTO.Constants
{
    public class BranchDto : ConstantDto, IMapFrom
    {
        public Guid OrgDepartmentId { get; set; }

        public OrgDepartmentDto? OrgDepartment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Branch, BranchDto>()
                    .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                    .ForMember(dest => dest.OrgDepartmentId, src => src.MapFrom(src => src.OrgDepartmentId))
                    .ForMember(dest => dest.OrgDepartment, src => src.MapFrom(src => src.OrgDepartment)).ReverseMap();
        }
    }
}