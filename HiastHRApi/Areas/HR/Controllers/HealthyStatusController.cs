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
    public class HealthyStatusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HealthyStatusController> _logger;
        private readonly IHealthyStatusService _healthystatusService;
        public HealthyStatusController(IUnitOfWork unitOfWork, ILogger<HealthyStatusController> logger, IHealthyStatusService healthystatusService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _healthystatusService = healthystatusService;
        }
        // GET: api/<HealthyStatuss>
        [HttpGet(nameof(GetHealthyStatuss))]
        [DisplayActionName(DisplayName = "استعلام الحالات الصحية")]
        public IActionResult GetHealthyStatuss([FromQuery]SieveModel sieveModel) => Ok(_healthystatusService.GetAll(sieveModel));

        [HttpPost(nameof(CreateHealthyStatus))]
        [DisplayActionName(DisplayName = "إنشاء حالة صحية جديدة")]
        public async Task<IActionResult> CreateHealthyStatus(HealthyStatusDto healthystatus)
        {
            if (ModelState.IsValid)
            {
                await _healthystatusService.Add(healthystatus);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=healthystatus };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateHealthyStatus))]
        [DisplayActionName(DisplayName = "تعديل الحالة الصحية")]
        public async Task<IActionResult> UpdateHealthyStatus(HealthyStatusDto healthystatus)
        {
            if (ModelState.IsValid)
            {
                await _healthystatusService.Update(healthystatus);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = healthystatus };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteHealthyStatus))]
        [DisplayActionName(DisplayName = "حذف الحالة الصحية")]
        public async Task<IActionResult> DeleteHealthyStatus(Guid id)
        {
            if (ModelState.IsValid)
            {
                _healthystatusService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
