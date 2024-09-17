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
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IUnitOfWork unitOfWork, ILogger<DepartmentController> logger, IDepartmentService departmentService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _departmentService = departmentService;
        }
        // GET: api/<Departments>
        [HttpGet(nameof(GetDepartments))]
        [DisplayActionName(DisplayName = "استعلام الأقسام")]
        public IActionResult GetDepartments([FromQuery] SieveModel sieveModel) => Ok(_departmentService.GetAll(sieveModel));

        [HttpPost(nameof(CreateDepartment))]
        [DisplayActionName(DisplayName = "إضافة قسم")]
        public async Task<IActionResult> CreateDepartment(DepartmentDto department)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.Add(department);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=department };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateDepartment))]
        [DisplayActionName(DisplayName = "تعديل قسم")]
        public async Task<IActionResult> UpdateDepartment(DepartmentDto department)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.Update(department);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = department };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteDepartment))]
        [DisplayActionName(DisplayName = "حذف قسم")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            if (ModelState.IsValid)
            {
                _departmentService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
