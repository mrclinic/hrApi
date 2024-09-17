using AutoMapper;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpRewardDto : EntityDto, IMapFrom
    {
        public DateTime OrderDate { get; set; }

        public DateTime ExecutionDate { get; set; }

        public DateTime ContractDate { get; set; }

        public Guid RewardTypeId { get; set; }

        public Guid DepartmentId { get; set; }

        public Guid ContractTypeId { get; set; }

        public int DurationInDays { get; set; }

        public int PercentageOrAmount { get; set; }

        public Guid FinancialIndicatorTypeId { get; set; }

        public string Reason { get; set; }

        public string OrderNumber { get; set; }

        public string ContractNumber { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Role, RoleDto>().ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
        }
    }
}