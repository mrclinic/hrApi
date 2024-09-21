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
    public class InsuranceSystemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<InsuranceSystemController> _logger;
        private readonly IInsuranceSystemService _insurancesystemService;
        public InsuranceSystemController(IUnitOfWork unitOfWork, ILogger<InsuranceSystemController> logger, IInsuranceSystemService insurancesystemService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _insurancesystemService = insurancesystemService;
        }
        // GET: api/<InsuranceSystems>
        [HttpGet(nameof(GetInsuranceSystems))]
        [DisplayActionName(DisplayName = "استعلام أنظمة التأمين الصحي")]
        public IActionResult GetInsuranceSystems([FromQuery]SieveModel sieveModel) => Ok(_insurancesystemService.GetAll(sieveModel));

        [HttpPost(nameof(CreateInsuranceSystem))]
        [DisplayActionName(DisplayName = "إنشاء نظام تأمين الصحي جديد")]
        public async Task<IActionResult> CreateInsuranceSystem(InsuranceSystemDto insurancesystem)
        {
            if (ModelState.IsValid)
            {
                await _insurancesystemService.Add(insurancesystem);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=insurancesystem };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateInsuranceSystem))]
        [DisplayActionName(DisplayName = "تعديل نظام التأمين الصحي")]
        public async Task<IActionResult> UpdateInsuranceSystem(InsuranceSystemDto insurancesystem)
        {
            if (ModelState.IsValid)
            {
                await _insurancesystemService.Update(insurancesystem);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = insurancesystem };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteInsuranceSystem))]
        [DisplayActionName(DisplayName = "حذف نظام التأمين الصحي")]
        public async Task<IActionResult> DeleteInsuranceSystem(Guid id)
        {
            if (ModelState.IsValid)
            {
                _insurancesystemService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
