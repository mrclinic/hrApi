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
    public class RolePermissionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RolePermissionsController> _logger;
        private readonly IRolePermissionsService _rolePermissionsService;
        public RolePermissionsController(IUnitOfWork unitOfWork, ILogger<RolePermissionsController> logger, IRolePermissionsService rolePermissionsService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _rolePermissionsService = rolePermissionsService;
        }
        // GET: api/<RolePermissions>
        [HttpGet(nameof(GetRolePermissions))]
        public IActionResult GetRolePermissions([FromQuery] SieveModel sieveModel) => Ok(_rolePermissionsService.GetAll(sieveModel));

        [HttpGet(nameof(GetRolePermissionsInfo))]
        public IActionResult GetRolePermissionsInfo([FromQuery] SieveModel sieveModel) => Ok(_rolePermissionsService.Get(sieveModel, includeProperties: "Role,Permission"));

        [HttpPost(nameof(CreateRolePermission))]
        public async Task<IActionResult> CreateRolePermission(RolePermissionsDto rolePermissions)
        {
            if (ModelState.IsValid)
            {
                await _rolePermissionsService.Add(rolePermissions);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = rolePermissions };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPost(nameof(SetRolePermission))]
        public async Task<IActionResult> SetRolePermission(List<RolePermissionsDto> rolePermissions,Guid roleId)
        {
            if (ModelState.IsValid)
            {
                _rolePermissionsService.DeleteMultiAsync(p => p.RoleId.Equals(roleId));
                if (rolePermissions.Count > 0)
                    await _rolePermissionsService.AddRange(rolePermissions);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = rolePermissions };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }


        [HttpPut(nameof(UpdateRolePermission))]
        [DisplayActionName(DisplayName = "تعديل صلاحية")]
        public async Task<IActionResult> UpdateRolePermission(RolePermissionsDto rolePermissions)
        {
            if (ModelState.IsValid)
            {
                await _rolePermissionsService.Update(rolePermissions);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = rolePermissions };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteRolePermission))]
        [DisplayActionName(DisplayName = "حذف صلاحية")]
        public async Task<IActionResult> DeleteRolePermission(Guid id)
        {
            if (ModelState.IsValid)
            {
                _rolePermissionsService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
