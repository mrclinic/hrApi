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
    public class DisabilityTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DisabilityTypeController> _logger;
        private readonly IDisabilityTypeService _disabilitytypeService;
        public DisabilityTypeController(IUnitOfWork unitOfWork, ILogger<DisabilityTypeController> logger, IDisabilityTypeService disabilitytypeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _disabilitytypeService = disabilitytypeService;
        }
        // GET: api/<DisabilityTypes>
        [HttpGet(nameof(GetDisabilityTypes))]
        [DisplayActionName(DisplayName = "استعلام أنواع الإعاقات")]
        public IActionResult GetDisabilityTypes([FromQuery]SieveModel sieveModel) => Ok(_disabilitytypeService.GetAll(sieveModel));

        [HttpPost(nameof(CreateDisabilityType))]
        [DisplayActionName(DisplayName = "إنشاء نوع إعاقة جديد")]
        public async Task<IActionResult> CreateDisabilityType(DisabilityTypeDto disabilitytype)
        {
            if (ModelState.IsValid)
            {
                await _disabilitytypeService.Add(disabilitytype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=disabilitytype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateDisabilityType))]
        [DisplayActionName(DisplayName = "تعديل نوع الإعاقة")]
        public async Task<IActionResult> UpdateDisabilityType(DisabilityTypeDto disabilitytype)
        {
            if (ModelState.IsValid)
            {
                await _disabilitytypeService.Update(disabilitytype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = disabilitytype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteDisabilityType))]
        [DisplayActionName(DisplayName = "حذف نوع الإعاقة")]
        public async Task<IActionResult> DeleteDisabilityType(Guid id)
        {
            if (ModelState.IsValid)
            {
                _disabilitytypeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
