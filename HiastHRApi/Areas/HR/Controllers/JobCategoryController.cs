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
    public class JobCategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobCategoryController> _logger;
        private readonly IJobCategoryService _jobcategoryService;
        public JobCategoryController(IUnitOfWork unitOfWork, ILogger<JobCategoryController> logger, IJobCategoryService jobcategoryService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _jobcategoryService = jobcategoryService;
        }
        // GET: api/<JobCategorys>
        [HttpGet(nameof(GetJobCategorys))]
        [DisplayActionName(DisplayName = "استعلام الفئات")]
        public IActionResult GetJobCategorys([FromQuery]SieveModel sieveModel) => Ok(_jobcategoryService.GetAll(sieveModel));

        [HttpPost(nameof(CreateJobCategory))]
        [DisplayActionName(DisplayName = "إنشاء فئة جديدة")]
        public async Task<IActionResult> CreateJobCategory(JobCategoryDto jobcategory)
        {
            if (ModelState.IsValid)
            {
                await _jobcategoryService.Add(jobcategory);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=jobcategory };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateJobCategory))]
        [DisplayActionName(DisplayName = "تعديل الفئة")]
        public async Task<IActionResult> UpdateJobCategory(JobCategoryDto jobcategory)
        {
            if (ModelState.IsValid)
            {
                await _jobcategoryService.Update(jobcategory);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = jobcategory };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteJobCategory))]
        [DisplayActionName(DisplayName = "حذف الفئة")]
        public async Task<IActionResult> DeleteJobCategory(Guid id)
        {
            if (ModelState.IsValid)
            {
                _jobcategoryService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
