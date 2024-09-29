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
    public class EmpMilitaryServiceCohortController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpMilitaryServiceCohortController> _logger;
        private readonly IEmpMilitaryServiceCohortService _empmilitaryservicecohortService;
        public EmpMilitaryServiceCohortController(IUnitOfWork unitOfWork, ILogger<EmpMilitaryServiceCohortController> logger, IEmpMilitaryServiceCohortService empmilitaryservicecohortService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empmilitaryservicecohortService = empmilitaryservicecohortService;
        }
        // GET: api/<EmpMilitaryServiceCohorts>
        [HttpGet(nameof(GetEmpMilitaryServiceCohorts))]
        [DisplayActionName(DisplayName = "استعلام دورات خدمة العلم")]
        public IActionResult GetEmpMilitaryServiceCohorts([FromQuery]SieveModel sieveModel) => Ok(_empmilitaryservicecohortService.GetAll(sieveModel));

        [HttpGet(nameof(GetEmpMilitaryServiceCohortsInfo))]
        [DisplayActionName(DisplayName = "استعلام دورات خدمة العلم وتفاصيلها")]
        public IActionResult GetEmpMilitaryServiceCohortsInfo([FromQuery] SieveModel sieveModel) => Ok(_empmilitaryservicecohortService.Get(sieveModel));

        [HttpPost(nameof(CreateEmpMilitaryServiceCohort))]
        [DisplayActionName(DisplayName = "إنشاء دورة علم جديدة")]
        public async Task<IActionResult> CreateEmpMilitaryServiceCohort(EmpMilitaryServiceCohortDto empmilitaryservicecohort)
        {
            if (ModelState.IsValid)
            {
                await _empmilitaryservicecohortService.Add(empmilitaryservicecohort);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=empmilitaryservicecohort };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpMilitaryServiceCohort))]
        [DisplayActionName(DisplayName = "تعديل دورة علم")]
        public async Task<IActionResult> UpdateEmpMilitaryServiceCohort(EmpMilitaryServiceCohortDto empmilitaryservicecohort)
        {
            if (ModelState.IsValid)
            {
                await _empmilitaryservicecohortService.Update(empmilitaryservicecohort);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empmilitaryservicecohort };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpMilitaryServiceCohort))]
        [DisplayActionName(DisplayName = "حذف دورة علم")]
        public async Task<IActionResult> DeleteEmpMilitaryServiceCohort(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empmilitaryservicecohortService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
