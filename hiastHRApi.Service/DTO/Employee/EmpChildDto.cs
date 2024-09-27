using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpChildDto : EntityDto, IMapFrom
    {
        public DateTime? BirthDate { get; set; }
        public DateTime? OccurrenceDate { get; set; }
        public int ChildOrder { get; set; }
        public Guid GenderId { get; set; }
        public GenderDto? Gender { get; set; }
        public Guid StatusId { get; set; }
        public ChildStatusDto? ChildStatus { get; set; }
        public string Name { get; set; }
        public string MotherName { get; set; }
        public string OccurrenceContractNumber { get; set; }
        public string Note { get; set; } = null!;
        public Guid EmployeeId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpChild, EmpChildDto>()
                .ForMember(dest => dest.BirthDate, src => src.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.OccurrenceDate, src => src.MapFrom(src => src.OccurrenceDate))
                .ForMember(dest => dest.ChildOrder, src => src.MapFrom(src => src.ChildOrder))
                .ForMember(dest => dest.GenderId, src => src.MapFrom(src => src.GenderId))
                .ForMember(dest => dest.Gender, src => src.MapFrom(src => src.Gender))
                .ForMember(dest => dest.StatusId, src => src.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.ChildStatus, src => src.MapFrom(src => src.Status))
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.MotherName, src => src.MapFrom(src => src.MotherName))
                .ForMember(dest => dest.OccurrenceContractNumber, src => src.MapFrom(src => src.OccurrenceContractNumber))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                .ReverseMap();
        }
    }
}