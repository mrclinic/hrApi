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
    public class EmpVacationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpVacationController> _logger;
        private readonly IEmpVacationService _empvacationService;
        public EmpVacationController(IUnitOfWork unitOfWork, ILogger<EmpVacationController> logger, IEmpVacationService empvacationService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empvacationService = empvacationService;
        }
        // GET: api/<EmpVacations>
        [HttpGet(nameof(GetEmpVacations))]
        [DisplayActionName(DisplayName = "استعلام الإجازات")]
        public IActionResult GetEmpVacations([FromQuery] SieveModel sieveModel) => Ok(_empvacationService.GetAll(sieveModel));

        [HttpGet(nameof(GetEmpVacationsInfo))]
        [DisplayActionName(DisplayName = "استعلام الإجازات وتفاصيلها")]
        public IActionResult GetEmpVacationsInfo([FromQuery] SieveModel sieveModel) => Ok(_empvacationService.Get(sieveModel, includeProperties: "ContractType,FinancialImpact,ForcedVacationType,ModificationContractType,VacationType"));

        [HttpPost(nameof(CreateEmpVacation))]
        [DisplayActionName(DisplayName = "إنشاء إجازة جديدة")]
        public async Task<IActionResult> CreateEmpVacation(EmpVacationDto empvacation)
        {
            if (ModelState.IsValid)
            {
                await _empvacationService.Add(empvacation);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empvacation };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpVacation))]
        [DisplayActionName(DisplayName = "تعديل إجازة")]
        public async Task<IActionResult> UpdateEmpVacation(EmpVacationDto empvacation)
        {
            if (ModelState.IsValid)
            {
                await _empvacationService.Update(empvacation);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empvacation };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpVacation))]
        [DisplayActionName(DisplayName = "حذف إجازة")]
        public async Task<IActionResult> DeleteEmpVacation(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empvacationService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
