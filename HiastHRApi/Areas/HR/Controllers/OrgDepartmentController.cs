using hiastHRApi.Authorization;
using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Service.IService.Constants;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;


namespace hiastHRApi.Areas.HR.Controllers
{
    [Area("HR")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class OrgDepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OrgDepartmentController> _logger;
        private readonly IOrgDepartmentService _orgDepartmentService;
        public OrgDepartmentController(IUnitOfWork unitOfWork, ILogger<OrgDepartmentController> logger, IOrgDepartmentService orgDepartmentService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _orgDepartmentService = orgDepartmentService;
        }
        // GET: api/<OrgDepartments>
        [HttpGet(nameof(GetOrgDepartments))]
        [DisplayActionName(DisplayName = "استعلام الجهات المصدرة")]
        public IActionResult GetOrgDepartments([FromQuery] SieveModel sieveModel) => Ok(_orgDepartmentService.GetAll(sieveModel));

        [HttpGet(nameof(GetOrgDepartmentsInfo))]
        [DisplayActionName(DisplayName = "استعلام معلومات الجهات المصدرة")]
        public IActionResult GetOrgDepartmentsInfo([FromQuery] SieveModel sieveModel) => Ok(_orgDepartmentService.Get(sieveModel, includeProperties: "SubOrgDepartments"));

        [HttpPost(nameof(CreateOrgDepartment))]
        [DisplayActionName(DisplayName = "إضافة جهة مصدرة جديدة")]
        public async Task<IActionResult> CreateOrgDepartment(OrgDepartmentDto OrgDepartment)
        {
            if (ModelState.IsValid)
            {
                await _orgDepartmentService.Add(OrgDepartment);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = OrgDepartment };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateOrgDepartment))]
        [DisplayActionName(DisplayName = "تعديل الجهة المصدرة")]
        public async Task<IActionResult> UpdateOrgDepartment(OrgDepartmentDto OrgDepartment)
        {
            if (ModelState.IsValid)
            {
                await _orgDepartmentService.Update(OrgDepartment);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = OrgDepartment };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteOrgDepartment))]
        [DisplayActionName(DisplayName = "حذف الجهة المصدرة")]
        public async Task<IActionResult> DeleteOrgDepartment(Guid id)
        {
            if (ModelState.IsValid)
            {
                _orgDepartmentService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
