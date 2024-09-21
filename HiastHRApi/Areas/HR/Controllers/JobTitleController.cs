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
    public class JobTitleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobTitleController> _logger;
        private readonly IJobTitleService _jobtitleService;
        public JobTitleController(IUnitOfWork unitOfWork, ILogger<JobTitleController> logger, IJobTitleService jobtitleService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _jobtitleService = jobtitleService;
        }
        // GET: api/<JobTitles>
        [HttpGet(nameof(GetJobTitles))]
        [DisplayActionName(DisplayName = "استعلام المسميات الوظيفية")]
        public IActionResult GetJobTitles([FromQuery]SieveModel sieveModel) => Ok(_jobtitleService.GetAll(sieveModel));

        [HttpPost(nameof(CreateJobTitle))]
        [DisplayActionName(DisplayName = "إنشاء مسمى وظيفي جديد")]
        public async Task<IActionResult> CreateJobTitle(JobTitleDto jobtitle)
        {
            if (ModelState.IsValid)
            {
                await _jobtitleService.Add(jobtitle);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=jobtitle };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateJobTitle))]
        [DisplayActionName(DisplayName = "تعديل المسمى الوظيفي")]
        public async Task<IActionResult> UpdateJobTitle(JobTitleDto jobtitle)
        {
            if (ModelState.IsValid)
            {
                await _jobtitleService.Update(jobtitle);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = jobtitle };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteJobTitle))]
        [DisplayActionName(DisplayName = "حذف المسمى الوظيفي")]
        public async Task<IActionResult> DeleteJobTitle(Guid id)
        {
            if (ModelState.IsValid)
            {
                _jobtitleService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
