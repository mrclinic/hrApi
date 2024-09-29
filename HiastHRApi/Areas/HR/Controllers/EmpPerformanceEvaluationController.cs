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
    public class EmpPerformanceEvaluationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpPerformanceEvaluationController> _logger;
        private readonly IEmpPerformanceEvaluationService _empperformanceevaluationService;
        public EmpPerformanceEvaluationController(IUnitOfWork unitOfWork, ILogger<EmpPerformanceEvaluationController> logger, IEmpPerformanceEvaluationService empperformanceevaluationService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empperformanceevaluationService = empperformanceevaluationService;
        }
        // GET: api/<EmpPerformanceEvaluations>
        [HttpGet(nameof(GetEmpPerformanceEvaluations))]
        [DisplayActionName(DisplayName = "استعلام التقييمات")]
        public IActionResult GetEmpPerformanceEvaluations([FromQuery]SieveModel sieveModel) => Ok(_empperformanceevaluationService.GetAll(sieveModel));
        [HttpGet(nameof(GetEmpPerformanceEvaluationsInfo))]
        [DisplayActionName(DisplayName = "استعلام التقييمات وتفاصليها")]
        public IActionResult GetEmpPerformanceEvaluationsInfo([FromQuery] SieveModel sieveModel) => Ok(_empperformanceevaluationService.Get(sieveModel, includeProperties: "EvaluationGrade,EvaluationQuarter"));

        [HttpPost(nameof(CreateEmpPerformanceEvaluation))]
        [DisplayActionName(DisplayName = "إنشاء تقييم جديد")]
        public async Task<IActionResult> CreateEmpPerformanceEvaluation(EmpPerformanceEvaluationDto empperformanceevaluation)
        {
            if (ModelState.IsValid)
            {
                await _empperformanceevaluationService.Add(empperformanceevaluation);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=empperformanceevaluation };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpPerformanceEvaluation))]
        [DisplayActionName(DisplayName = "تعديل تقييم")]
        public async Task<IActionResult> UpdateEmpPerformanceEvaluation(EmpPerformanceEvaluationDto empperformanceevaluation)
        {
            if (ModelState.IsValid)
            {
                await _empperformanceevaluationService.Update(empperformanceevaluation);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empperformanceevaluation };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpPerformanceEvaluation))]
        [DisplayActionName(DisplayName = "حذف تقييم")]
        public async Task<IActionResult> DeleteEmpPerformanceEvaluation(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empperformanceevaluationService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
