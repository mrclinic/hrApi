using hiastHRApi.Authorization;
using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Service.DTO.Employee;
using hiastHRApi.Service.IService.Employee;
using hiastHRApi.Service.Service.Employee;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;


namespace hiastHRApi.Areas.HR.Controllers
{
    [Area("HR")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class EmpExperienceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpExperienceController> _logger;
        private readonly IEmpExperienceService _empexperienceService;
        public EmpExperienceController(IUnitOfWork unitOfWork, ILogger<EmpExperienceController> logger, IEmpExperienceService empexperienceService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empexperienceService = empexperienceService;
        }
        // GET: api/<EmpExperiences>
        [HttpGet(nameof(GetEmpExperiences))]
        [DisplayActionName(DisplayName = "استعلام الخبرات")]
        public IActionResult GetEmpExperiences([FromQuery]SieveModel sieveModel) => Ok(_empexperienceService.GetAll(sieveModel));
        [HttpGet(nameof(GetEmpExperiencesInfo))]
        [DisplayActionName(DisplayName = "استعلام الخبرات وتفاصيلها")]
        public IActionResult GetEmpExperiencesInfo([FromQuery] SieveModel sieveModel) => Ok(_empexperienceService.Get(sieveModel, includeProperties: "ExperienceType"));


        [HttpPost(nameof(CreateEmpExperience))]
        [DisplayActionName(DisplayName = "إنشاء خبرة جديدة")]
        public async Task<IActionResult> CreateEmpExperience(EmpExperienceDto empexperience)
        {
            if (ModelState.IsValid)
            {
                await _empexperienceService.Add(empexperience);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=empexperience };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpExperience))]
        [DisplayActionName(DisplayName = "تعديل خبرة")]
        public async Task<IActionResult> UpdateEmpExperience(EmpExperienceDto empexperience)
        {
            if (ModelState.IsValid)
            {
                await _empexperienceService.Update(empexperience);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empexperience };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpExperience))]
        [DisplayActionName(DisplayName = "حذف خبرة")]
        public async Task<IActionResult> DeleteEmpExperience(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empexperienceService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
