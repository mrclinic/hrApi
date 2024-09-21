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
    public class JobChangeReasonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobChangeReasonController> _logger;
        private readonly IJobChangeReasonService _jobchangereasonService;
        public JobChangeReasonController(IUnitOfWork unitOfWork, ILogger<JobChangeReasonController> logger, IJobChangeReasonService jobchangereasonService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _jobchangereasonService = jobchangereasonService;
        }
        // GET: api/<JobChangeReasons>
        [HttpGet(nameof(GetJobChangeReasons))]
        [DisplayActionName(DisplayName = "استعلام أسباب تبديل العمل")]
        public IActionResult GetJobChangeReasons([FromQuery]SieveModel sieveModel) => Ok(_jobchangereasonService.GetAll(sieveModel));

        [HttpPost(nameof(CreateJobChangeReason))]
        [DisplayActionName(DisplayName = "إنشاء سبب تبديل العمل جديد")]
        public async Task<IActionResult> CreateJobChangeReason(JobChangeReasonDto jobchangereason)
        {
            if (ModelState.IsValid)
            {
                await _jobchangereasonService.Add(jobchangereason);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=jobchangereason };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateJobChangeReason))]
        [DisplayActionName(DisplayName = "تعديل سبب تبديل العمل")]
        public async Task<IActionResult> UpdateJobChangeReason(JobChangeReasonDto jobchangereason)
        {
            if (ModelState.IsValid)
            {
                await _jobchangereasonService.Update(jobchangereason);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = jobchangereason };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteJobChangeReason))]
        [DisplayActionName(DisplayName = "حذف سبب تبديل العمل")]
        public async Task<IActionResult> DeleteJobChangeReason(Guid id)
        {
            if (ModelState.IsValid)
            {
                _jobchangereasonService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
