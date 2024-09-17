using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class PersonDto : EntityDto, IMapFrom
    {
        public Guid IdentityUserId { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? FamilyBookDate { get; set; }

        public string? ImagePath { get; set; }

        public Guid EmploymentStatusTypeId { get; set; }

        public EmploymentStatusTypeDto EmploymentStatusType { get; set; }

        public Guid GenderId { get; set; }

        public GenderDto Gender { get; set; }

        public Guid NationalityId { get; set; }

        public NationalityDto Nationality { get; set; }

        public Guid MaritalStatusId { get; set; }

        public MaritalStatusDto MaritalStatus { get; set; }

        public Guid BloodGroupId { get; set; }

        public BloodGroupDto BloodGroup { get; set; }

        public Guid CityId { get; set; }

        public CityDto City { get; set; }

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
                    .ForMember(dest => dest.Address, src => src.MapFrom(src => src.Address))
                    .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id));
        }
    }
}