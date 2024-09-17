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
    public class RewardTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RewardTypeController> _logger;
        private readonly IRewardTypeService _rewardtypeService;
        public RewardTypeController(IUnitOfWork unitOfWork, ILogger<RewardTypeController> logger, IRewardTypeService rewardtypeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _rewardtypeService = rewardtypeService;
        }
        // GET: api/<RewardTypes>
        [HttpGet(nameof(GetRewardTypes))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetRewardTypes([FromQuery]SieveModel sieveModel) => Ok(_rewardtypeService.GetAll(sieveModel));

        [HttpPost(nameof(CreateRewardType))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateRewardType(RewardTypeDto rewardtype)
        {
            if (ModelState.IsValid)
            {
                await _rewardtypeService.Add(rewardtype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=rewardtype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateRewardType))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateRewardType(RewardTypeDto rewardtype)
        {
            if (ModelState.IsValid)
            {
                await _rewardtypeService.Update(rewardtype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = rewardtype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteRewardType))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteRewardType(Guid id)
        {
            if (ModelState.IsValid)
            {
                _rewardtypeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
