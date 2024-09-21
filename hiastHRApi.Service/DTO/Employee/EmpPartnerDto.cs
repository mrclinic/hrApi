using AutoMapper;

using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpPartnerDto : EntityDto, IMapFrom
    {
        public DateTime? BirthDate { get; set; }

        public DateTime? OccurrenceDate { get; set; }

        public int PartnerOrder { get; set; }

        public Guid GenderId { get; set; }
        public GenderDto Gender { get; set; }

        public Guid NationalityId { get; set; }
        public NationalityDto Nationality { get; set; }

        public Guid OccurrenceTypeId { get; set; }
        public OccurrencePartnerTypeDto OccurrenceType { get; set; }

        public Guid PartnerWorkId { get; set; }
        public JobTitleDto PartnerWork { get; set; }

        public string MotherName { get; set; }

        public string Name { get; set; }

        public string OccurrenceContractNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpPartner, EmpPartnerDto>()
                .ForMember(dest => dest.BirthDate, src => src.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.OccurrenceDate, src => src.MapFrom(src => src.OccurrenceDate))
                .ForMember(dest => dest.PartnerOrder, src => src.MapFrom(src => src.PartnerOrder))
                .ForMember(dest => dest.GenderId, src => src.MapFrom(src => src.GenderId))
                .ForMember(dest => dest.Gender, src => src.MapFrom(src => src.Gender))
                .ForMember(dest => dest.NationalityId, src => src.MapFrom(src => src.NationalityId))
                .ForMember(dest => dest.Nationality, src => src.MapFrom(src => src.Nationality))
                .ForMember(dest => dest.OccurrenceTypeId, src => src.MapFrom(src => src.OccurrenceTypeId))
                .ForMember(dest => dest.OccurrenceType, src => src.MapFrom(src => src.OccurrenceType))
                .ForMember(dest => dest.PartnerWorkId, src => src.MapFrom(src => src.PartnerWorkId))
                .ForMember(dest => dest.PartnerWork, src => src.MapFrom(src => src.PartnerWork))
                .ForMember(dest => dest.MotherName, src => src.MapFrom(src => src.MotherName))
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.OccurrenceContractNumber, src => src.MapFrom(src => src.OccurrenceContractNumber))
                .ReverseMap();
        }
    }
}