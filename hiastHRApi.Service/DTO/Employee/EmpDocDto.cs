using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Service.DTO.Employee
{
    public class EmpDocDto : EntityDto, IMapFrom
    {
        public DateTime? DocDate { get; set; }
        public string? DocNumber { get; set; } = string.Empty;
        public string? DocSrc { get; set; } = string.Empty;
        public string? DocDescription { get; set; } = string.Empty;
        public byte[] Content { get; set; }
        public Guid DocTypeId { get; set; }
        public string? Note { get; set; } = null!;
        public virtual DocType? DocType { get; set; } = null!;
        public Guid? RefId { get; set; }
        public Guid EmployeeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmpDoc, EmpDocDto>()
                    .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                    .ForMember(dest => dest.DocDate, src => src.MapFrom(src => src.DocDate))
                    .ForMember(dest => dest.DocNumber, src => src.MapFrom(src => src.DocNumber))
                    .ForMember(dest => dest.DocSrc, src => src.MapFrom(src => src.DocSrc))
                    .ForMember(dest => dest.DocDescription, src => src.MapFrom(src => src.DocDescription))
                    .ForMember(dest => dest.Content, src => src.MapFrom(src => src.Content))
                    .ForMember(dest => dest.DocTypeId, src => src.MapFrom(src => src.DocTypeId))
                    .ForMember(dest => dest.Note, src => src.MapFrom(src => src.Note))
                    .ForMember(dest => dest.RefId, src => src.MapFrom(src => src.RefId))
                    .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.EmployeeId))
                    .ReverseMap();
        }
    }
}