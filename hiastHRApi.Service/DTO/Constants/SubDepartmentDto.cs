using AutoMapper;

using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Shared.Common.Mapping;

namespace hiastHRApi.Service.DTO.Constants
{
    public class SubDepartmentDto : ConstantDto, IMapFrom
    {
        public Guid DepartmentId { get; set; }

        public DepartmentDto? Department { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SubDepartment, SubDepartmentDto>()
                                            .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                                            .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                                            .ForMember(dest => dest.DepartmentId, src => src.MapFrom(src => src.DepartmentId))
                                            .ForMember(dest => dest.Department, src => src.MapFrom(src => src.Department))
                                            .ReverseMap();
        }
    }
}