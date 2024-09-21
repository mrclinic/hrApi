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
    public class DeputationStatusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeputationStatusController> _logger;
        private readonly IDeputationStatusService _deputationstatusService;
        public DeputationStatusController(IUnitOfWork unitOfWork, ILogger<DeputationStatusController> logger, IDeputationStatusService deputationstatusService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _deputationstatusService = deputationstatusService;
        }
        // GET: api/<DeputationStatuss>
        [HttpGet(nameof(GetDeputationStatuss))]
        [DisplayActionName(DisplayName = "استعلام أوضاع الإيفاد وتغيرات")]
        public IActionResult GetDeputationStatuss([FromQuery]SieveModel sieveModel) => Ok(_deputationstatusService.GetAll(sieveModel));

        [HttpPost(nameof(CreateDeputationStatus))]
        [DisplayActionName(DisplayName = "إنشاء وضع إيفاد جديد")]
        public async Task<IActionResult> CreateDeputationStatus(DeputationStatusDto deputationstatus)
        {
            if (ModelState.IsValid)
            {
                await _deputationstatusService.Add(deputationstatus);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=deputationstatus };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateDeputationStatus))]
        [DisplayActionName(DisplayName = "تعديل وضع الإيفاد")]
        public async Task<IActionResult> UpdateDeputationStatus(DeputationStatusDto deputationstatus)
        {
            if (ModelState.IsValid)
            {
                await _deputationstatusService.Update(deputationstatus);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = deputationstatus };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteDeputationStatus))]
        [DisplayActionName(DisplayName = "حذف وضع الإيفاد")]
        public async Task<IActionResult> DeleteDeputationStatus(Guid id)
        {
            if (ModelState.IsValid)
            {
                _deputationstatusService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
