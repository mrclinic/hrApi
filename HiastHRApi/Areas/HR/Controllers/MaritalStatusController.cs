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
    public class MaritalStatusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MaritalStatusController> _logger;
        private readonly IMaritalStatusService _maritalstatusService;
        public MaritalStatusController(IUnitOfWork unitOfWork, ILogger<MaritalStatusController> logger, IMaritalStatusService maritalstatusService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _maritalstatusService = maritalstatusService;
        }
        // GET: api/<MaritalStatuss>
        [HttpGet(nameof(GetMaritalStatuss))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetMaritalStatuss([FromQuery]SieveModel sieveModel) => Ok(_maritalstatusService.GetAll(sieveModel));

        [HttpPost(nameof(CreateMaritalStatus))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateMaritalStatus(MaritalStatusDto maritalstatus)
        {
            if (ModelState.IsValid)
            {
                await _maritalstatusService.Add(maritalstatus);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=maritalstatus };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateMaritalStatus))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateMaritalStatus(MaritalStatusDto maritalstatus)
        {
            if (ModelState.IsValid)
            {
                await _maritalstatusService.Update(maritalstatus);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = maritalstatus };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteMaritalStatus))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteMaritalStatus(Guid id)
        {
            if (ModelState.IsValid)
            {
                _maritalstatusService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
