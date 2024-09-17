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
    public class TerminationReasonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TerminationReasonController> _logger;
        private readonly ITerminationReasonService _terminationreasonService;
        public TerminationReasonController(IUnitOfWork unitOfWork, ILogger<TerminationReasonController> logger, ITerminationReasonService terminationreasonService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _terminationreasonService = terminationreasonService;
        }
        // GET: api/<TerminationReasons>
        [HttpGet(nameof(GetTerminationReasons))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetTerminationReasons([FromQuery]SieveModel sieveModel) => Ok(_terminationreasonService.GetAll(sieveModel));

        [HttpPost(nameof(CreateTerminationReason))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateTerminationReason(TerminationReasonDto terminationreason)
        {
            if (ModelState.IsValid)
            {
                await _terminationreasonService.Add(terminationreason);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=terminationreason };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateTerminationReason))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateTerminationReason(TerminationReasonDto terminationreason)
        {
            if (ModelState.IsValid)
            {
                await _terminationreasonService.Update(terminationreason);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = terminationreason };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteTerminationReason))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteTerminationReason(Guid id)
        {
            if (ModelState.IsValid)
            {
                _terminationreasonService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
