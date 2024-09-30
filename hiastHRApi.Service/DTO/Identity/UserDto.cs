using AutoMapper;

using hiastHRApi.Domain.Entities.Identity;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.Common.Mapping;
using hiastHRApi.Services.Common.Models;

namespace hiastHRApi.Services.DTO.Identity
{
    public class UserDto : EntityDto, IMapFrom
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Phone { get; set; }
        public string NatNum { get; set; }
        public string EmailAddress { get; set; }
        public string? UserToken { get; set; }
        public bool IsActive { get; set; }
        public Guid RoleID { get; set; }
        public RoleDto? Role { get; set; }
        public IList<String>? Permissions { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>().ForMember(dest => dest.FName, src => src.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LName, src => src.MapFrom(src => src.LastName))
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Username))
                .ForMember(dest => dest.PassWord, src => src.MapFrom(src => src.Password))
                .ForMember(dest => dest.Phone, src => src.MapFrom(src => src.Mobile))
                .ForMember(dest => dest.NatNum, src => src.MapFrom(src => src.NationalNumber))
                .ForMember(dest => dest.EmailAddress, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserToken, src => src.MapFrom(src => src.Token))
                .ForMember(dest => dest.RoleID, src => src.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.Role, src => src.MapFrom(src => src.Role))
                .ForMember(dest => dest.IsActive, src => src.MapFrom(src => src.IsActive)).ReverseMap();
        }
    }
}
