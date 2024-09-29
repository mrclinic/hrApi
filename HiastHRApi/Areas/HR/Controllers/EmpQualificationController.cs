using hiastHRApi.Authorization;
using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Service.DTO.Employee;
using hiastHRApi.Service.IService.Employee;
using hiastHRApi.Service.Service.Employee;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;


namespace hiastHRApi.Areas.HR.Controllers
{
    [Area("HR")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class EmpQualificationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpQualificationController> _logger;
        private readonly IEmpQualificationService _empqualificationService;
        public EmpQualificationController(IUnitOfWork unitOfWork, ILogger<EmpQualificationController> logger, IEmpQualificationService empqualificationService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empqualificationService = empqualificationService;
        }
        // GET: api/<EmpQualifications>
        [HttpGet(nameof(GetEmpQualifications))]
        [DisplayActionName(DisplayName = "استعلام المؤهلات العلمية للموظف")]
        public IActionResult GetEmpQualifications([FromQuery]SieveModel sieveModel) => Ok(_empqualificationService.GetAll(sieveModel));
        [HttpGet(nameof(GetEmpQualificationsInfo))]
        [DisplayActionName(DisplayName = "استعلام المؤهلات العلمية للموظف وتفاصيلها")]
        public IActionResult GetEmpQualificationsInfo([FromQuery] SieveModel sieveModel) => Ok(_empqualificationService.Get(sieveModel, includeProperties: "DegreesAuthority,Qualification,Specialization,Country"));

        [HttpPost(nameof(CreateEmpQualification))]
        [DisplayActionName(DisplayName = "إنشاء مؤهل علمي للموظف جديد")]
        public async Task<IActionResult> CreateEmpQualification(EmpQualificationDto empqualification)
        {
            if (ModelState.IsValid)
            {
                await _empqualificationService.Add(empqualification);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=empqualification };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpQualification))]
        [DisplayActionName(DisplayName = "تعديل مؤهل علمي للموظف")]
        public async Task<IActionResult> UpdateEmpQualification(EmpQualificationDto empqualification)
        {
            if (ModelState.IsValid)
            {
                await _empqualificationService.Update(empqualification);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empqualification };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpQualification))]
        [DisplayActionName(DisplayName = "حذف مؤهل علمي للموظف")]
        public async Task<IActionResult> DeleteEmpQualification(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empqualificationService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
