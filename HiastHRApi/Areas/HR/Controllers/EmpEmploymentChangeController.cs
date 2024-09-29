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
    public class EmpEmploymentChangeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpEmploymentChangeController> _logger;
        private readonly IEmpEmploymentChangeService _empemploymentchangeService;
        public EmpEmploymentChangeController(IUnitOfWork unitOfWork, ILogger<EmpEmploymentChangeController> logger, IEmpEmploymentChangeService empemploymentchangeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empemploymentchangeService = empemploymentchangeService;
        }
        // GET: api/<EmpEmploymentChanges>
        [HttpGet(nameof(GetEmpEmploymentChanges))]
        [DisplayActionName(DisplayName = "استعلام التبدلات الوظيفية")]
        public IActionResult GetEmpEmploymentChanges([FromQuery] SieveModel sieveModel) => Ok(_empemploymentchangeService.GetAll(sieveModel));

        [HttpGet(nameof(GetEmpEmploymentChangesInfo))]
        [DisplayActionName(DisplayName = "استعلام التبدلات الوظيفية وتفاصيلها")]
        public IActionResult GetEmpEmploymentChangesInfo([FromQuery] SieveModel sieveModel) => Ok(_empemploymentchangeService.Get(sieveModel, includeProperties: "JobChangeReason,JobTitle,ModificationContractType"));


        [HttpPost(nameof(CreateEmpEmploymentChange))]
        [DisplayActionName(DisplayName = "إنشاء تبدل وظيفي جديد")]
        public async Task<IActionResult> CreateEmpEmploymentChange(EmpEmploymentChangeDto empemploymentchange)
        {
            if (ModelState.IsValid)
            {
                await _empemploymentchangeService.Add(empemploymentchange);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empemploymentchange };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpEmploymentChange))]
        [DisplayActionName(DisplayName = "تعديل تبدل وظيفي")]
        public async Task<IActionResult> UpdateEmpEmploymentChange(EmpEmploymentChangeDto empemploymentchange)
        {
            if (ModelState.IsValid)
            {
                await _empemploymentchangeService.Update(empemploymentchange);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empemploymentchange };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpEmploymentChange))]
        [DisplayActionName(DisplayName = "حذف تبدل وظيفي")]
        public async Task<IActionResult> DeleteEmpEmploymentChange(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empemploymentchangeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
