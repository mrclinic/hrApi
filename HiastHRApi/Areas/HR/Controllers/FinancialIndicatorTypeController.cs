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
    public class FinancialIndicatorTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FinancialIndicatorTypeController> _logger;
        private readonly IFinancialIndicatorTypeService _financialindicatortypeService;
        public FinancialIndicatorTypeController(IUnitOfWork unitOfWork, ILogger<FinancialIndicatorTypeController> logger, IFinancialIndicatorTypeService financialindicatortypeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _financialindicatortypeService = financialindicatortypeService;
        }
        // GET: api/<FinancialIndicatorTypes>
        [HttpGet(nameof(GetFinancialIndicatorTypes))]
        [DisplayActionName(DisplayName = "استعلام أنواع المؤشرات المالية")]
        public IActionResult GetFinancialIndicatorTypes([FromQuery]SieveModel sieveModel) => Ok(_financialindicatortypeService.GetAll(sieveModel));

        [HttpPost(nameof(CreateFinancialIndicatorType))]
        [DisplayActionName(DisplayName = "إنشاء نوع مؤشر مالي جديد")]
        public async Task<IActionResult> CreateFinancialIndicatorType(FinancialIndicatorTypeDto financialindicatortype)
        {
            if (ModelState.IsValid)
            {
                await _financialindicatortypeService.Add(financialindicatortype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=financialindicatortype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateFinancialIndicatorType))]
        [DisplayActionName(DisplayName = "تعديل نوع المؤشر المالي")]
        public async Task<IActionResult> UpdateFinancialIndicatorType(FinancialIndicatorTypeDto financialindicatortype)
        {
            if (ModelState.IsValid)
            {
                await _financialindicatortypeService.Update(financialindicatortype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = financialindicatortype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteFinancialIndicatorType))]
        [DisplayActionName(DisplayName = "حذف نوع المؤشر المالي")]
        public async Task<IActionResult> DeleteFinancialIndicatorType(Guid id)
        {
            if (ModelState.IsValid)
            {
                _financialindicatortypeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
