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
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;
        public RoleController(IUnitOfWork unitOfWork, ILogger<RoleController> logger, IRoleService roleService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _roleService = roleService;
        }

        // GET: api/<Roles>
        [HttpGet(nameof(GetRoles))]
        [DisplayActionName(DisplayName = "استعلام جميع الأدوار")]
        public IActionResult GetRoles([FromQuery] SieveModel sieveModel) => Ok(_roleService.GetAll(sieveModel));

        [HttpPost(nameof(CreateRole))]
        [DisplayActionName(DisplayName = "إضافة دور جديد")]
        public async Task<IActionResult> CreateRole(RoleDto role)
        {
            if (ModelState.IsValid)
            {
                await _roleService.Add(role);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = role };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateRole))]
        [DisplayActionName(DisplayName = "تعديل دور")]
        public async Task<IActionResult> UpdateRole(RoleDto role)
        {
            if (ModelState.IsValid)
            {
                await _roleService.Update(role);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = role };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteRole))]
        [DisplayActionName(DisplayName = "حذف دور")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            if (ModelState.IsValid)
            {
                _roleService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
