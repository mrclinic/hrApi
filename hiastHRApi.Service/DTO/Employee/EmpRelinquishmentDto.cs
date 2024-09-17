using AutoMapper;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpRelinquishmentDto : EntityDto, IMapFrom
    {
        public DateTime RelinquishmentDate { get; set; }

        public DateTime ContractDate { get; set; }

        public Guid RelinquishmentReasonId { get; set; }

        public Guid ContractTypeId { get; set; }

        public string ContractNumber { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Role, RoleDto>().ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
        }
    }
}