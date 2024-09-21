using AutoMapper;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpPunishmentDto : EntityDto, IMapFrom
    {
        public DateTime ExecutionDate { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ContractDate { get; set; }

        public Guid IssuingDepartmentId { get; set; }

        public int DurationInDays { get; set; }

        public Guid OrderDepartmentId { get; set; }

        public bool IsAppearingInRecordCard { get; set; }

        public Guid ContractTypeId { get; set; }

        public Guid PunishmentTypeId { get; set; }

        public int PercentageOrAmount { get; set; }

        public bool IsPercentage { get; set; }

        public string Reason { get; set; }

        public string OrderContractNumber { get; set; }

        public string ContractNumber { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Role, RoleDto>().ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
        }
    }
}