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
    public class EvaluationGradeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EvaluationGradeController> _logger;
        private readonly IEvaluationGradeService _evaluationgradeService;
        public EvaluationGradeController(IUnitOfWork unitOfWork, ILogger<EvaluationGradeController> logger, IEvaluationGradeService evaluationgradeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _evaluationgradeService = evaluationgradeService;
        }
        // GET: api/<EvaluationGrades>
        [HttpGet(nameof(GetEvaluationGrades))]
        [DisplayActionName(DisplayName = "استعلام درجات التقييم")]
        public IActionResult GetEvaluationGrades([FromQuery]SieveModel sieveModel) => Ok(_evaluationgradeService.GetAll(sieveModel));

        [HttpPost(nameof(CreateEvaluationGrade))]
        [DisplayActionName(DisplayName = "إنشاء درجة تقييم جديدة")]
        public async Task<IActionResult> CreateEvaluationGrade(EvaluationGradeDto evaluationgrade)
        {
            if (ModelState.IsValid)
            {
                await _evaluationgradeService.Add(evaluationgrade);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=evaluationgrade };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEvaluationGrade))]
        [DisplayActionName(DisplayName = "تعديل درجة التقييم")]
        public async Task<IActionResult> UpdateEvaluationGrade(EvaluationGradeDto evaluationgrade)
        {
            if (ModelState.IsValid)
            {
                await _evaluationgradeService.Update(evaluationgrade);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = evaluationgrade };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEvaluationGrade))]
        [DisplayActionName(DisplayName = "حذف درجة التقييم")]
        public async Task<IActionResult> DeleteEvaluationGrade(Guid id)
        {
            if (ModelState.IsValid)
            {
                _evaluationgradeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
