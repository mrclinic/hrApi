
using hiastHRApi.Domain.Entities.Identity;
using hiastHRApi.Services.DTO.Identity;
using hiastHRApi.Services.IService;


namespace hiastHRApi.Service.IService.Identity
{
    public interface IUserService : IServiceAsync<User, UserDto>
    {
        Task<UserDto> LogIn(string userName, string passWord);
        Task<UserDto> getUserInfo(Guid userID);
        Task<UserDto> SignUp(UserDto user, string code);

        Task<bool> Activate(string userName, string activateCode);
        Task<bool> ChangePassword(Guid userID, string currentPassword, string newPassword);
    }
}
