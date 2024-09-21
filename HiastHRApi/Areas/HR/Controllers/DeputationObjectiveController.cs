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
    public class DeputationObjectiveController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeputationObjectiveController> _logger;
        private readonly IDeputationObjectiveService _deputationobjectiveService;
        public DeputationObjectiveController(IUnitOfWork unitOfWork, ILogger<DeputationObjectiveController> logger, IDeputationObjectiveService deputationobjectiveService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _deputationobjectiveService = deputationobjectiveService;
        }
        // GET: api/<DeputationObjectives>
        [HttpGet(nameof(GetDeputationObjectives))]
        [DisplayActionName(DisplayName = "استعلام أهداف الايفاد")]
        public IActionResult GetDeputationObjectives([FromQuery]SieveModel sieveModel) => Ok(_deputationobjectiveService.GetAll(sieveModel));

        [HttpPost(nameof(CreateDeputationObjective))]
        [DisplayActionName(DisplayName = "إنشاء هدف إيفاد جديد")]
        public async Task<IActionResult> CreateDeputationObjective(DeputationObjectiveDto deputationobjective)
        {
            if (ModelState.IsValid)
            {
                await _deputationobjectiveService.Add(deputationobjective);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=deputationobjective };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateDeputationObjective))]
        [DisplayActionName(DisplayName = "تعديل هدف الإيفاد")]
        public async Task<IActionResult> UpdateDeputationObjective(DeputationObjectiveDto deputationobjective)
        {
            if (ModelState.IsValid)
            {
                await _deputationobjectiveService.Update(deputationobjective);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = deputationobjective };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteDeputationObjective))]
        [DisplayActionName(DisplayName = "حذف هدف الإيفاد")]
        public async Task<IActionResult> DeleteDeputationObjective(Guid id)
        {
            if (ModelState.IsValid)
            {
                _deputationobjectiveService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
