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
    [Authorize]
    public class PermissionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PermissionController> _logger;
        private readonly IPermissionService _permissionService;
        public PermissionController(IUnitOfWork unitOfWork, ILogger<PermissionController> logger, IPermissionService permissionService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _permissionService = permissionService;
        }

        // GET: api/<Permissions>
        [HttpGet(nameof(GetPermissions))]
        [DisplayActionName(DisplayName = "استعلام جميع الصلاحيات")]
        public IActionResult GetPermissions([FromQuery] SieveModel sieveModel) => Ok(_permissionService.Get(sieveModel));

        [HttpPost(nameof(CreatePermission))]
        [DisplayActionName(DisplayName = "إضافة صلاحية جديدة")]
        public async Task<IActionResult> CreatePermission(PermissionDto Permission)
        {
            if (ModelState.IsValid)
            {
                await _permissionService.Add(Permission);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = Permission };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdatePermission))]
        [DisplayActionName(DisplayName = "تعديل صلاحية")]
        public async Task<IActionResult> UpdatePermission(PermissionDto Permission)
        {
            if (ModelState.IsValid)
            {
                await _permissionService.Update(Permission);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = Permission };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeletePermission))]
        [DisplayActionName(DisplayName = "حذف صلاحية")]
        public async Task<IActionResult> DeletePermission(Guid id)
        {
            if (ModelState.IsValid)
            {
                _permissionService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
