using AutoMapper;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpVacationDto : EntityDto, IMapFrom
    {
        public DateTime StartDate { get; set; }

        public DateTime ContractDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime ModificationContractDate { get; set; }

        public DateTime ActualReturnDate { get; set; }

        public int DurationInDays { get; set; }

        public Guid VacationTypeId { get; set; }

        public int VacationYear { get; set; }

        public Guid ContractTypeId { get; set; }

        public bool IsAppearingInRecordCard { get; set; }

        public Guid FinancialImpactId { get; set; }

        public Guid ForcedVacationTypeId { get; set; }

        public bool IsIncludedInServiceDuration { get; set; }

        public Guid ModificationContractTypeId { get; set; }

        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public string ContractNumber { get; set; }

        public string ModificationContractNumber { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Role, RoleDto>().ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
        }
    }
}