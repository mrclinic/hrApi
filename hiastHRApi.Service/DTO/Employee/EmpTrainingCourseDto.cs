using AutoMapper;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpTrainingCourseDto : EntityDto, IMapFrom
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime ContractDate { get; set; }

        public Guid ContractTypeId { get; set; }

        public bool DisplayOnRecordCard { get; set; }

        public string CourseName { get; set; }

        public string CourseSource { get; set; }

        public string ContractNumber { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Role, RoleDto>().ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
        }
    }
}