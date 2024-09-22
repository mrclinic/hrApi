using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
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
        public DegreesAuthorityDto DegreesAuthority { get; set; }
        public PersonDto Employee { get; set; }
        public QualificationDto Qualification { get; set; }
        public SpecializationDto Specialization { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpQualification, EmpQualificationDto>()
                .ForMember(dest => dest.DegreeDate, src => src.MapFrom(src => src.DegreeDate))
                .ForMember(dest => dest.EquivalenceDegreeContractDate, src => src.MapFrom(src => src.EquivalenceDegreeContractDate))
                .ForMember(dest => dest.SpecializationId, src => src.MapFrom(src => src.SpecializationId))
                .ForMember(dest => dest.DegreesAuthorityId, src => src.MapFrom(src => src.DegreesAuthorityId))
                .ForMember(dest => dest.CountryId, src => src.MapFrom(src => src.CountryId))
                .ForMember(dest => dest.QualificationId, src => src.MapFrom(src => src.QualificationId))
                .ForMember(dest => dest.SubSpecialization, src => src.MapFrom(src => src.SubSpecialization))
                .ForMember(dest => dest.EquivalenceContractNumber, src => src.MapFrom(src => src.EquivalenceContractNumber))
                .ForMember(dest => dest.DegreesAuthority, src => src.MapFrom(src => src.DegreesAuthority))
                .ForMember(dest => dest.Employee, src => src.MapFrom(src => src.Employee))
                .ForMember(dest => dest.Qualification, src => src.MapFrom(src => src.Qualification))
                .ForMember(dest => dest.Specialization, src => src.MapFrom(src => src.Specialization))
                .ReverseMap();
        }
    }
}