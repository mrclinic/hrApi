using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Services.Common.Mapping;

namespace hiastHRApi.Service.DTO.Constants
{
    public class DepartmentDto : ConstantDto, IMapFrom
    {
        public ICollection<SubDepartmentDto> SubDepartments { get; set; } = new List<SubDepartmentDto>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Department, DepartmentDto>()
                     .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                     .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                     .ForMember(dest => dest.SubDepartments, src => src.MapFrom(src => src.SubDepartments))
                     .ReverseMap();
        }
    }
}