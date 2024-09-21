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
    public class EvaluationQuarterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EvaluationQuarterController> _logger;
        private readonly IEvaluationQuarterService _evaluationquarterService;
        public EvaluationQuarterController(IUnitOfWork unitOfWork, ILogger<EvaluationQuarterController> logger, IEvaluationQuarterService evaluationquarterService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _evaluationquarterService = evaluationquarterService;
        }
        // GET: api/<EvaluationQuarters>
        [HttpGet(nameof(GetEvaluationQuarters))]
        [DisplayActionName(DisplayName = "استعلام أرباع التقييمات")]
        public IActionResult GetEvaluationQuarters([FromQuery]SieveModel sieveModel) => Ok(_evaluationquarterService.GetAll(sieveModel));

        [HttpPost(nameof(CreateEvaluationQuarter))]
        [DisplayActionName(DisplayName = "إنشاء ربع تقييم جديد")]
        public async Task<IActionResult> CreateEvaluationQuarter(EvaluationQuarterDto evaluationquarter)
        {
            if (ModelState.IsValid)
            {
                await _evaluationquarterService.Add(evaluationquarter);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=evaluationquarter };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEvaluationQuarter))]
        [DisplayActionName(DisplayName = "تعديل ربع التقييم")]
        public async Task<IActionResult> UpdateEvaluationQuarter(EvaluationQuarterDto evaluationquarter)
        {
            if (ModelState.IsValid)
            {
                await _evaluationquarterService.Update(evaluationquarter);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = evaluationquarter };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEvaluationQuarter))]
        [DisplayActionName(DisplayName = "حذف ربع التقييم")]
        public async Task<IActionResult> DeleteEvaluationQuarter(Guid id)
        {
            if (ModelState.IsValid)
            {
                _evaluationquarterService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
