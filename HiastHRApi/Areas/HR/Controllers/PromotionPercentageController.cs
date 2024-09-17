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
    public class PromotionPercentageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PromotionPercentageController> _logger;
        private readonly IPromotionPercentageService _promotionpercentageService;
        public PromotionPercentageController(IUnitOfWork unitOfWork, ILogger<PromotionPercentageController> logger, IPromotionPercentageService promotionpercentageService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _promotionpercentageService = promotionpercentageService;
        }
        // GET: api/<PromotionPercentages>
        [HttpGet(nameof(GetPromotionPercentages))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetPromotionPercentages([FromQuery]SieveModel sieveModel) => Ok(_promotionpercentageService.GetAll(sieveModel));

        [HttpPost(nameof(CreatePromotionPercentage))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreatePromotionPercentage(PromotionPercentageDto promotionpercentage)
        {
            if (ModelState.IsValid)
            {
                await _promotionpercentageService.Add(promotionpercentage);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=promotionpercentage };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdatePromotionPercentage))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdatePromotionPercentage(PromotionPercentageDto promotionpercentage)
        {
            if (ModelState.IsValid)
            {
                await _promotionpercentageService.Update(promotionpercentage);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = promotionpercentage };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeletePromotionPercentage))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeletePromotionPercentage(Guid id)
        {
            if (ModelState.IsValid)
            {
                _promotionpercentageService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
