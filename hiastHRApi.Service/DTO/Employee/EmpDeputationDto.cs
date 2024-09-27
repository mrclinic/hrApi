using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;
using Sieve.Attributes;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpDeputationDto : EntityDto, IMapFrom
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DeputationDecisionDate { get; set; }
        public DateTime ExecutiveContractDate { get; set; }
        public DateTime StartAfterReturnDate { get; set; }
        public Guid CountryId { get; set; }
        public CountryDto? Country { get; set; }
        public Guid CityId { get; set; }
        public CityDto? City { get; set; }
        public Guid UniversityId { get; set; }
        public UniversityDto? University { get; set; }
        public Guid DeputationObjectiveId { get; set; }
        public DeputationObjectiveDto? DeputationObjective { get; set; }
        public Guid DeputationStatusId { get; set; }
        public DeputationStatusDto? DeputationStatus { get; set; }
        public Guid DeputationTypeId { get; set; }
        public DeputationTypeDto? DeputationType { get; set; }
        public string Duration { get; set; }
        public string DeputationDecisionNumber { get; set; }
        public string RequiredSpecialization { get; set; }
        public string ExecutiveContractNumber { get; set; }
        public string AssignedEntity { get; set; }
        public string DeputationReason { get; set; }
        public string Note { get; set; } = null!;
        public Guid EmployeeId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpDeputation, EmpDeputationDto>()
                .ForMember(dest => dest.RequiredSpecialization, src => src.MapFrom(src => src.RequiredSpecialization))
                .ForMember(dest => dest.Duration, src => src.MapFrom(src => src.Duration))
                .ForMember(dest => dest.EndDate, src => src.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.ReturnDate, src => src.MapFrom(src => src.ReturnDate))
                .ForMember(dest => dest.DeputationStatusId, src => src.MapFrom(src => src.DeputationStatusId))
                .ForMember(dest => dest.DeputationStatus, src => src.MapFrom(src => src.DeputationStatus))
                .ForMember(dest => dest.ExecutiveContractNumber, src => src.MapFrom(src => src.ExecutiveContractNumber))
                .ForMember(dest => dest.ExecutiveContractDate, src => src.MapFrom(src => src.ExecutiveContractDate))
                .ForMember(dest => dest.AssignedEntity, src => src.MapFrom(src => src.AssignedEntity))
                .ForMember(dest => dest.City, src => src.MapFrom(src => src.City))
                .ForMember(dest => dest.CityId, src => src.MapFrom(src => src.CityId))
                .ForMember(dest => dest.Country, src => src.MapFrom(src => src.Country))
                .ForMember(dest => dest.CountryId, src => src.MapFrom(src => src.CountryId))
                .ForMember(dest => dest.DeputationDecisionDate, src => src.MapFrom(src => src.DeputationDecisionDate))
                .ForMember(dest => dest.DeputationDecisionNumber, src => src.MapFrom(src => src.DeputationDecisionNumber))
                .ForMember(dest => dest.DeputationReason, src => src.MapFrom(src => src.DeputationReason))
                .ForMember(dest => dest.StartDate, src => src.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.StartAfterReturnDate, src => src.MapFrom(src => src.StartAfterReturnDate))
                .ForMember(dest => dest.UniversityId, src => src.MapFrom(src => src.UniversityId))
                .ForMember(dest => dest.University, src => src.MapFrom(src => src.University))
                .ForMember(dest => dest.DeputationObjectiveId, src => src.MapFrom(src => src.DeputationObjectiveId))
                .ForMember(dest => dest.DeputationObjective, src => src.MapFrom(src => src.DeputationObjective))
                .ForMember(dest => dest.DeputationTypeId, src => src.MapFrom(src => src.DeputationTypeId))
                .ForMember(dest => dest.DeputationType, src => src.MapFrom(src => src.DeputationType))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                .ReverseMap();

        }
    }
}