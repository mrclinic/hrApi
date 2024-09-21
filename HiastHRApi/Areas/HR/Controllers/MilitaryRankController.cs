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
    public class MilitaryRankController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MilitaryRankController> _logger;
        private readonly IMilitaryRankService _militaryrankService;
        public MilitaryRankController(IUnitOfWork unitOfWork, ILogger<MilitaryRankController> logger, IMilitaryRankService militaryrankService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _militaryrankService = militaryrankService;
        }
        // GET: api/<MilitaryRanks>
        [HttpGet(nameof(GetMilitaryRanks))]
        [DisplayActionName(DisplayName = "استعلام الرتب العسكرية")]
        public IActionResult GetMilitaryRanks([FromQuery]SieveModel sieveModel) => Ok(_militaryrankService.GetAll(sieveModel));

        [HttpPost(nameof(CreateMilitaryRank))]
        [DisplayActionName(DisplayName = "إنشاء رتبة عسكرية جديدة")]
        public async Task<IActionResult> CreateMilitaryRank(MilitaryRankDto militaryrank)
        {
            if (ModelState.IsValid)
            {
                await _militaryrankService.Add(militaryrank);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=militaryrank };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateMilitaryRank))]
        [DisplayActionName(DisplayName = "تعديل الرتبة العسكرية")]
        public async Task<IActionResult> UpdateMilitaryRank(MilitaryRankDto militaryrank)
        {
            if (ModelState.IsValid)
            {
                await _militaryrankService.Update(militaryrank);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = militaryrank };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteMilitaryRank))]
        [DisplayActionName(DisplayName = "حذف الرتبة العسكرية")]
        public async Task<IActionResult> DeleteMilitaryRank(Guid id)
        {
            if (ModelState.IsValid)
            {
                _militaryrankService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
