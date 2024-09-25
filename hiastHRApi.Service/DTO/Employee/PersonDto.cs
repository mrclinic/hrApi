using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Shared.Common.Mapping;
using hiastHRApi.Shared.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class PersonDto : EntityDto, IMapFrom
    {
        public Guid IdentityUserId { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? FamilyBookDate { get; set; }
        public string? ImagePath { get; set; }
        public Guid EmploymentStatusTypeId { get; set; }
        public EmploymentStatusTypeDto? EmploymentStatusType { get; set; }
        public Guid GenderId { get; set; }
        public GenderDto? Gender { get; set; }
        public Guid NationalityId { get; set; }
        public NationalityDto? Nationality { get; set; }
        public Guid MaritalStatusId { get; set; }
        public MaritalStatusDto? MaritalStatus { get; set; }
        public Guid BloodGroupId { get; set; }
        public BloodGroupDto? BloodGroup { get; set; }
        public Guid CityId { get; set; }
        public CityDto? City { get; set; }
        public int? RegistrationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string BirthPlace { get; set; }
        public string? RegistrationPlaceAndNumber { get; set; }
        public string? Address { get; set; }
        public string? NationalNumber { get; set; }
        public string? IDNumber { get; set; }
        public string? CivilRegistry { get; set; }
        public string? FamilyBookNumber { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string Note { get; set; }

        public void Mapping(Profile profile)
        {

            profile.CreateMap<EmpPersonalInfo, PersonDto>()
                    .ForMember(dest => dest.IdentityUserId, src => src.MapFrom(src => src.IdentityUserId))
                    .ForMember(dest => dest.BirthDate, src => src.MapFrom(src => src.BirthDate))
                    .ForMember(dest => dest.FamilyBookDate, src => src.MapFrom(src => src.FamilyBookDate))
                    .ForMember(dest => dest.ImagePath, src => src.MapFrom(src => src.ImagePath))
                    .ForMember(dest => dest.EmploymentStatusTypeId, src => src.MapFrom(src => src.EmploymentStatusTypeId))
                    .ForMember(dest => dest.EmploymentStatusType, src => src.MapFrom(src => src.EmploymentStatusType))
                    .ForMember(dest => dest.GenderId, src => src.MapFrom(src => src.GenderId))
                    .ForMember(dest => dest.Gender, src => src.MapFrom(src => src.Gender))
                    .ForMember(dest => dest.NationalityId, src => src.MapFrom(src => src.NationalityId))
                    .ForMember(dest => dest.Nationality, src => src.MapFrom(src => src.Nationality))
                    .ForMember(dest => dest.MaritalStatusId, src => src.MapFrom(src => src.MaritalStatusId))
                    .ForMember(dest => dest.MaritalStatus, src => src.MapFrom(src => src.MaritalStatus))
                    .ForMember(dest => dest.BloodGroupId, src => src.MapFrom(src => src.BloodGroupId))
                    .ForMember(dest => dest.BloodGroup, src => src.MapFrom(src => src.BloodGroup))
                    .ForMember(dest => dest.CityId, src => src.MapFrom(src => src.CityId))
                    .ForMember(dest => dest.City, src => src.MapFrom(src => src.City))
                    .ForMember(dest => dest.RegistrationNumber, src => src.MapFrom(src => src.RegistrationNumber))
                    .ForMember(dest => dest.FirstName, src => src.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.LastName, src => src.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.FatherName, src => src.MapFrom(src => src.FatherName))
                    .ForMember(dest => dest.MotherName, src => src.MapFrom(src => src.MotherName))
                    .ForMember(dest => dest.BirthPlace, src => src.MapFrom(src => src.BirthPlace))
                    .ForMember(dest => dest.RegistrationPlaceAndNumber, src => src.MapFrom(src => src.RegistrationPlaceAndNumber))
                    .ForMember(dest => dest.Address, src => src.MapFrom(src => src.Address))
                    .ForMember(dest => dest.NationalNumber, src => src.MapFrom(src => src.NationalNumber))
                    .ForMember(dest => dest.IDNumber, src => src.MapFrom(src => src.Idnumber))
                    .ForMember(dest => dest.CivilRegistry, src => src.MapFrom(src => src.CivilRegistry))
                    .ForMember(dest => dest.FamilyBookNumber, src => src.MapFrom(src => src.FamilyBookNumber))
                    .ForMember(dest => dest.Phone, src => src.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                    .ReverseMap();
        }
    }
}