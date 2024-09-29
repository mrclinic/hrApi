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
    public class EmploymentStatusTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmploymentStatusTypeController> _logger;
        private readonly IEmploymentStatusTypeService _employmentstatustypeService;
        public EmploymentStatusTypeController(IUnitOfWork unitOfWork, ILogger<EmploymentStatusTypeController> logger, IEmploymentStatusTypeService employmentstatustypeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _employmentstatustypeService = employmentstatustypeService;
        }
        // GET: api/<EmploymentStatusTypes>
        [HttpGet(nameof(GetEmploymentStatusTypes))]
        [DisplayActionName(DisplayName = "استعلام أنواع الأوضاع الوظيفية")]
        public IActionResult GetEmploymentStatusTypes([FromQuery]SieveModel sieveModel) => Ok(_employmentstatustypeService.GetAll(sieveModel));

        [HttpGet(nameof(GetEmploymentStatusTypesInfo))]
        [DisplayActionName(DisplayName = "استعلام أنواع الأوضاع الوظيفية وتفاصيلها")]
        public IActionResult GetEmploymentStatusTypesInfo([FromQuery] SieveModel sieveModel) => Ok(_employmentstatustypeService.Get(sieveModel));

        [HttpPost(nameof(CreateEmploymentStatusType))]
        [DisplayActionName(DisplayName = "إنشاء نوع وضع وظيفيي جديد")]
        public async Task<IActionResult> CreateEmploymentStatusType(EmploymentStatusTypeDto employmentstatustype)
        {
            if (ModelState.IsValid)
            {
                await _employmentstatustypeService.Add(employmentstatustype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=employmentstatustype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmploymentStatusType))]
        [DisplayActionName(DisplayName = "تعديل نوع وضع وظيفيي")]
        public async Task<IActionResult> UpdateEmploymentStatusType(EmploymentStatusTypeDto employmentstatustype)
        {
            if (ModelState.IsValid)
            {
                await _employmentstatustypeService.Update(employmentstatustype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = employmentstatustype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmploymentStatusType))]
        [DisplayActionName(DisplayName = "حذف نوع وضع وظيفيي")]
        public async Task<IActionResult> DeleteEmploymentStatusType(Guid id)
        {
            if (ModelState.IsValid)
            {
                _employmentstatustypeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
