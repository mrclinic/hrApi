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
    public class SubDepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SubDepartmentController> _logger;
        private readonly ISubDepartmentService _subdepartmentService;
        public SubDepartmentController(IUnitOfWork unitOfWork, ILogger<SubDepartmentController> logger, ISubDepartmentService subdepartmentService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _subdepartmentService = subdepartmentService;
        }
        // GET: api/<SubDepartments>
        [HttpGet(nameof(GetSubDepartments))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetSubDepartments([FromQuery]SieveModel sieveModel) => Ok(_subdepartmentService.GetAll(sieveModel));

        [HttpPost(nameof(CreateSubDepartment))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateSubDepartment(SubDepartmentDto subdepartment)
        {
            if (ModelState.IsValid)
            {
                await _subdepartmentService.Add(subdepartment);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=subdepartment };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateSubDepartment))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateSubDepartment(SubDepartmentDto subdepartment)
        {
            if (ModelState.IsValid)
            {
                await _subdepartmentService.Update(subdepartment);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = subdepartment };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteSubDepartment))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteSubDepartment(Guid id)
        {
            if (ModelState.IsValid)
            {
                _subdepartmentService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
