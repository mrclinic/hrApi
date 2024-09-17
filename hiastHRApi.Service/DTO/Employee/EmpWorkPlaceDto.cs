using AutoMapper;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpWorkPlaceDto : EntityDto, IMapFrom
    {
        public DateTime DateOfStart { get; set; }

        public DateTime DateOfRelinquishment { get; set; }

        public DateTime DateOfContract { get; set; }

        public Guid ContractTypeId { get; set; }

        public string ContractNumber { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Role, RoleDto>().ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
        }
    }
}