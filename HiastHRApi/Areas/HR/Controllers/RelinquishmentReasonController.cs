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
    public class RelinquishmentReasonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RelinquishmentReasonController> _logger;
        private readonly IRelinquishmentReasonService _relinquishmentreasonService;
        public RelinquishmentReasonController(IUnitOfWork unitOfWork, ILogger<RelinquishmentReasonController> logger, IRelinquishmentReasonService relinquishmentreasonService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _relinquishmentreasonService = relinquishmentreasonService;
        }
        // GET: api/<RelinquishmentReasons>
        [HttpGet(nameof(GetRelinquishmentReasons))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetRelinquishmentReasons([FromQuery]SieveModel sieveModel) => Ok(_relinquishmentreasonService.GetAll(sieveModel));

        [HttpPost(nameof(CreateRelinquishmentReason))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateRelinquishmentReason(RelinquishmentReasonDto relinquishmentreason)
        {
            if (ModelState.IsValid)
            {
                await _relinquishmentreasonService.Add(relinquishmentreason);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=relinquishmentreason };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateRelinquishmentReason))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateRelinquishmentReason(RelinquishmentReasonDto relinquishmentreason)
        {
            if (ModelState.IsValid)
            {
                await _relinquishmentreasonService.Update(relinquishmentreason);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = relinquishmentreason };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteRelinquishmentReason))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteRelinquishmentReason(Guid id)
        {
            if (ModelState.IsValid)
            {
                _relinquishmentreasonService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
