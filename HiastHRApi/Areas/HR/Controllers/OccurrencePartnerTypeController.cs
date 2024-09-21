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
    public class OccurrencePartnerTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OccurrencePartnerTypeController> _logger;
        private readonly IOccurrencePartnerTypeService _occurrencepartnertypeService;
        public OccurrencePartnerTypeController(IUnitOfWork unitOfWork, ILogger<OccurrencePartnerTypeController> logger, IOccurrencePartnerTypeService occurrencepartnertypeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _occurrencepartnertypeService = occurrencepartnertypeService;
        }
        // GET: api/<OccurrencePartnerTypes>
        [HttpGet(nameof(GetOccurrencePartnerTypes))]
        [DisplayActionName(DisplayName = "استعلام أنواع الواقعات في الزواجات")]
        public IActionResult GetOccurrencePartnerTypes([FromQuery]SieveModel sieveModel) => Ok(_occurrencepartnertypeService.GetAll(sieveModel));

        [HttpPost(nameof(CreateOccurrencePartnerType))]
        [DisplayActionName(DisplayName = "إنشاء نوع الواقعات في الزواجات جديد")]
        public async Task<IActionResult> CreateOccurrencePartnerType(OccurrencePartnerTypeDto occurrencepartnertype)
        {
            if (ModelState.IsValid)
            {
                await _occurrencepartnertypeService.Add(occurrencepartnertype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=occurrencepartnertype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateOccurrencePartnerType))]
        [DisplayActionName(DisplayName = "تعديل نوع الواقعات في الزواجات")]
        public async Task<IActionResult> UpdateOccurrencePartnerType(OccurrencePartnerTypeDto occurrencepartnertype)
        {
            if (ModelState.IsValid)
            {
                await _occurrencepartnertypeService.Update(occurrencepartnertype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = occurrencepartnertype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteOccurrencePartnerType))]
        [DisplayActionName(DisplayName = "حذف نوع الواقعات في الزواجات")]
        public async Task<IActionResult> DeleteOccurrencePartnerType(Guid id)
        {
            if (ModelState.IsValid)
            {
                _occurrencepartnertypeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
