using hiastHRApi.Areas.UserManagment.Models;
using hiastHRApi.Authorization;
using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Service.IService.Identity;
using hiastHRApi.Services.DTO.Identity;
using hiastHRApi.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;


namespace hiastHRApi.Areas.UserManagment.Controllers
{
    [Area("UserManagment")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IHelperService _helperService;
        public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger, IUserService userService,
             IHelperService helperService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userService = userService;
            _helperService = helperService;

        }
        // GET: api/<Users>
        [HttpGet(nameof(GetUsers))]
        [DisplayActionName(DisplayName = "استعلام جميع المستخدمين")]
        //[Authorize]
        public IActionResult GetUsers([FromQuery] SieveModel sieveModel) => Ok(_userService.GetAll(sieveModel));

        [HttpGet(nameof(GetUsersInfo))]
        [DisplayActionName(DisplayName = "استعلام جميع المستخدمين وتفاصيلهم")]
        //[Authorize]
        public IActionResult GetUsersInfo([FromQuery] SieveModel sieveModel) => Ok(_userService.Get(sieveModel, includeProperties: "Role"));

        [AllowAnonymous]
        [HttpGet(nameof(GetCode))]
        public IActionResult GetCode() => Ok(_helperService.GenerateLicenseKey(""));

        [HttpPost(nameof(CreateUser))]
        [DisplayActionName(DisplayName = "إضافة مستخدم جديد")]
        //[Authorize]
        public async Task<IActionResult> CreateUser(UserDto user)
        {
            if (ModelState.IsValid)
            {
                user.PassWord = BCrypt.Net.BCrypt.HashPassword(user.PassWord);
                await _userService.Add(user);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = user };
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateUser))]
        [DisplayActionName(DisplayName = "تعديل مستخدم")]
        //[Authorize]
        public async Task<IActionResult> UpdateUser(UserDto user)
        {
            if (ModelState.IsValid)
            {
                await _userService.Update(user);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = user };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteUser))]
        [DisplayActionName(DisplayName = "حذف مستخدم")]
        //[Authorize]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (ModelState.IsValid)
            {
                _userService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPost(nameof(logIn))]
        [AllowAnonymous]
        public async Task<IActionResult> logIn(LogInViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userDto = await _userService.LogIn(user.UserName, user.PassWord);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = userDto };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500, Value = null };
        }

        [HttpPost(nameof(SignUp))]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(UserDto user)
        {
            if (ModelState.IsValid)
            {
                string activationcode = _helperService.GenerateLicenseKey(string.Concat(user.EmailAddress, DateTime.Now.ToString()));
                await _userService.SignUp(user, activationcode);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = user };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPost(nameof(activateAccount))]
        [AllowAnonymous]
        public async Task<IActionResult> activateAccount(ActivateViewModel user)
        {
            if (ModelState.IsValid)
            {
                var isActive = await _userService.Activate(user.UserName, user.Code);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = isActive };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500, Value = false };
        }

        [HttpGet(nameof(getUserInfo))]
        [DisplayActionName(DisplayName = "استعلام معلومات المستخدم")]
        //[Authorize]
        public async Task<IActionResult> getUserInfo(Guid userID)
        {
            if (ModelState.IsValid)
            {
                var userDto = await _userService.getUserInfo(userID);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = userDto };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500, Value = null };
        }

        [HttpPost(nameof(changePassword))]
        [DisplayActionName(DisplayName = "تغيير كلمة المرور")]
        //[Authorize]
        public async Task<IActionResult> changePassword(ChangePasswordViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userDto = await _userService.ChangePassword(user.UserId, user.CurrentPassword, user.NewPassword);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = userDto };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500, Value = null };
        }
    }
}
