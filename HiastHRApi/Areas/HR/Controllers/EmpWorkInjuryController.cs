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
    public class EmpWorkInjuryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpWorkInjuryController> _logger;
        private readonly IEmpWorkInjuryService _empworkinjuryService;
        public EmpWorkInjuryController(IUnitOfWork unitOfWork, ILogger<EmpWorkInjuryController> logger, IEmpWorkInjuryService empworkinjuryService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empworkinjuryService = empworkinjuryService;
        }
        // GET: api/<EmpWorkInjurys>
        [HttpGet(nameof(GetEmpWorkInjurys))]
        [DisplayActionName(DisplayName = "استعلام إصابات العمل")]
        public IActionResult GetEmpWorkInjurys([FromQuery]SieveModel sieveModel) => Ok(_empworkinjuryService.GetAll(sieveModel));

        [HttpGet(nameof(GetEmpWorkInjurysInfo))]
        [DisplayActionName(DisplayName = "استعلام إصابات العمل وتفاصيلها")]
        public IActionResult GetEmpWorkInjurysInfo([FromQuery] SieveModel sieveModel) => Ok(_empworkinjuryService.Get(sieveModel));

        [HttpPost(nameof(CreateEmpWorkInjury))]
        [DisplayActionName(DisplayName = "إنشاء إصابة عمل جديدة")]
        public async Task<IActionResult> CreateEmpWorkInjury(EmpWorkInjuryDto empworkinjury)
        {
            if (ModelState.IsValid)
            {
                await _empworkinjuryService.Add(empworkinjury);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=empworkinjury };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpWorkInjury))]
        [DisplayActionName(DisplayName = "تعديل إصابة عمل")]
        public async Task<IActionResult> UpdateEmpWorkInjury(EmpWorkInjuryDto empworkinjury)
        {
            if (ModelState.IsValid)
            {
                await _empworkinjuryService.Update(empworkinjury);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empworkinjury };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpWorkInjury))]
        [DisplayActionName(DisplayName = "حذف إصابة عمل")]
        public async Task<IActionResult> DeleteEmpWorkInjury(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empworkinjuryService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
