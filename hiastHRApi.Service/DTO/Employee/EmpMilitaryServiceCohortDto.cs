using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpMilitaryServiceCohortDto : EntityDto, IMapFrom
    {
        public DateTime StartDate { get; set; }
        public DateTime StartContractDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EndContractDate { get; set; }
        public string StartContractNumber { get; set; }
        public string EndContractNumber { get; set; }
        public Guid EmployeeId { get; set; }
        public string Note { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpMilitaryServiceCohort, EmpMilitaryServiceCohortDto>()
                .ForMember(dest => dest.StartDate, src => src.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.StartContractDate, src => src.MapFrom(src => src.StartContractDate))
                .ForMember(dest => dest.EndDate, src => src.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.EndContractDate, src => src.MapFrom(src => src.EndContractDate))
                .ForMember(dest => dest.StartContractNumber, src => src.MapFrom(src => src.StartContractNumber))
                .ForMember(dest => dest.EndContractNumber, src => src.MapFrom(src => src.EndContractNumber))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                .ReverseMap();
        }
    }
}