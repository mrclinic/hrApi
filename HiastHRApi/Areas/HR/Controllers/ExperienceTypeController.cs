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
    public class ExperienceTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ExperienceTypeController> _logger;
        private readonly IExperienceTypeService _experiencetypeService;
        public ExperienceTypeController(IUnitOfWork unitOfWork, ILogger<ExperienceTypeController> logger, IExperienceTypeService experiencetypeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _experiencetypeService = experiencetypeService;
        }
        // GET: api/<ExperienceTypes>
        [HttpGet(nameof(GetExperienceTypes))]
        [DisplayActionName(DisplayName = "استعلام أنواع الخبرة")]
        public IActionResult GetExperienceTypes([FromQuery]SieveModel sieveModel) => Ok(_experiencetypeService.GetAll(sieveModel));

        [HttpPost(nameof(CreateExperienceType))]
        [DisplayActionName(DisplayName = "إنشاء نوع خبرة جديد")]
        public async Task<IActionResult> CreateExperienceType(ExperienceTypeDto experiencetype)
        {
            if (ModelState.IsValid)
            {
                await _experiencetypeService.Add(experiencetype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=experiencetype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateExperienceType))]
        [DisplayActionName(DisplayName = "تعديل نوع الخبرة")]
        public async Task<IActionResult> UpdateExperienceType(ExperienceTypeDto experiencetype)
        {
            if (ModelState.IsValid)
            {
                await _experiencetypeService.Update(experiencetype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = experiencetype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteExperienceType))]
        [DisplayActionName(DisplayName = "حذف نوع الخبرة")]
        public async Task<IActionResult> DeleteExperienceType(Guid id)
        {
            if (ModelState.IsValid)
            {
                _experiencetypeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
