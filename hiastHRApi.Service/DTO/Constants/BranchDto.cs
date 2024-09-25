using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Shared.Common.Mapping;

namespace hiastHRApi.Service.DTO.Constants
{
    public class BranchDto : ConstantDto, IMapFrom
    {
        public Guid DepartmentId { get; set; }

        public DepartmentDto? Department { get; set; }

        public Guid SubDepartmentId { get; set; }

        public SubDepartmentDto? SubDepartment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Branch, BranchDto>()
                    .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                    .ForMember(dest => dest.DepartmentId, src => src.MapFrom(src => src.DepartmentId))
                    .ForMember(dest => dest.SubDepartmentId, src => src.MapFrom(src => src.SubDepartmentId))
                    .ForMember(dest => dest.Department, src => src.MapFrom(src => src.Department))
                    .ForMember(dest => dest.SubDepartment, src => src.MapFrom(src => src.SubDepartment)).ReverseMap();
        }
    }
}