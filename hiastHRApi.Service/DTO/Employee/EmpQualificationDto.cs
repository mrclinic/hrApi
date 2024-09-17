using AutoMapper;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;
namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpQualificationDto : EntityDto, IMapFrom
    {
        public DateTime? DegreeDate { get; set; }

        public DateTime? EquivalenceDegreeContractDate { get; set; }

        public Guid SpecializationId { get; set; }

        public Guid DegreesAuthorityId { get; set; }

        public Guid CountryId { get; set; }

        public Guid QualificationId { get; set; }

        public string SubSpecialization { get; set; }

        public string EquivalenceContractNumber { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Role, RoleDto>().ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
        }
    }
}