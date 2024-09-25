using AutoMapper;

using hiastHRApi.Domain.Entities.Identity;
using hiastHRApi.Shared.Common.Mapping;
using hiastHRApi.Shared.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace hiastHRApi.Services.DTO.Identity
{
    public class UserProfileDto : EntityDto, IMapFrom
    {
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string BirthPlace { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string CardNumber { get; set; }
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserProfile, UserProfileDto>()
                .ForMember(dest => dest.Address, src => src.MapFrom(src => src.Address))
                .ForMember(dest => dest.BirthDate, src => src.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.BirthPlace, src => src.MapFrom(src => src.BirthPlace))
                .ForMember(dest => dest.CardNumber, src => src.MapFrom(src => src.PersonalCardNumber))
                .ForMember(dest => dest.FatherName, src => src.MapFrom(src => src.FatherName))
                .ForMember(dest => dest.Gender, src => src.MapFrom(src => src.Gender))
                .ForMember(dest => dest.MotherName, src => src.MapFrom(src => src.MotherName))
                .ForMember(dest => dest.User, src => src.MapFrom(src => src.User))
                .ForMember(dest => dest.UserId, src => src.MapFrom(src => src.UserId)).ReverseMap();
        }
    }
}
