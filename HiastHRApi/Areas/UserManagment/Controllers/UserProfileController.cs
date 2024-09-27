using hiastHRApi.Authorization;
using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Helpers;
using hiastHRApi.Service.IService.Identity;
using hiastHRApi.Services.DTO.Identity;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace hiastHRApi.Areas.UserManagment.Controllers
{
    [Area("UserManagment")]
    [Route("[area]/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserProfileController> _logger;
        private readonly IUserProfileService _userProfileService;
        public UserProfileController(IUnitOfWork unitOfWork, ILogger<UserProfileController> logger, IUserProfileService userProfileService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userProfileService = userProfileService;

        }
        // GET: api/<UserProfiles>
        [HttpGet(nameof(GetMyUserProfiles))]
        [DisplayActionName(DisplayName = "استعلام بروفايلي")]
        public IActionResult GetMyUserProfiles([FromQuery] SieveModel sieveModel) => Ok(_userProfileService.GetAll(sieveModel));
        [HttpGet(nameof(GetUserProfiles))]
        [DisplayActionName(DisplayName = "استعلام البروفايلات")]
        public IActionResult GetUserProfiles([FromQuery] SieveModel sieveModel) => Ok(_userProfileService.GetAll(sieveModel));

        [HttpGet(nameof(GetUserProfilesInfo))]
        [DisplayActionName(DisplayName = "استعلام البروفايلات وتفاصيلها")]
        public IActionResult GetUserProfilesInfo([FromQuery] SieveModel sieveModel) => Ok(_userProfileService.Get(sieveModel, includeProperties: "User"));

        [HttpGet(nameof(GetAllUserProfilesInfo))]
        [DisplayActionName(DisplayName = "استعلام البروفايلات للطلبات")]
        public IActionResult GetAllUserProfilesInfo([FromQuery] SieveModel sieveModel) => Ok(_userProfileService.Get(sieveModel, includeProperties: "User"));

        [HttpPost(nameof(CreateUserProfile))]
        [DisplayActionName(DisplayName = "إنشاء بروفايل جديد")]
        public async Task<IActionResult> CreateUserProfile(UserProfileDto userProfile)
        {
            if (ModelState.IsValid)
            {
                await _userProfileService.Add(userProfile);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = userProfile };
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateUserProfile))]
        [DisplayActionName(DisplayName = "تعديل بروفايل مستخدم")]
        public async Task<IActionResult> UpdateUserProfile(UserProfileDto userProfile)
        {
            if (ModelState.IsValid)
            {
                await _userProfileService.Update(userProfile);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = userProfile };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteUserProfile))]
        [DisplayActionName(DisplayName = "حذف بروفايل مستخدم")]
        public async Task<IActionResult> DeleteUserProfile(Guid id)
        {
            if (ModelState.IsValid)
            {
                _userProfileService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
