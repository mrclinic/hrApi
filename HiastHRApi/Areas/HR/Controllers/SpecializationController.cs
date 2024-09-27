using hiastHRApi.Authorization;
using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Service.IService.Constants;
using hiastHRApi.Service.Service.Constants;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;


namespace hiastHRApi.Areas.HR.Controllers
{
    [Area("HR")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SpecializationController> _logger;
        private readonly ISpecializationService _specializationService;
        public SpecializationController(IUnitOfWork unitOfWork, ILogger<SpecializationController> logger, ISpecializationService specializationService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _specializationService = specializationService;
        }
        // GET: api/<Specializations>
        [HttpGet(nameof(GetSpecializations))]
        [DisplayActionName(DisplayName = "استعلام الاختصاصات العلمية")]
        public IActionResult GetSpecializations([FromQuery]SieveModel sieveModel) => Ok(_specializationService.GetAll(sieveModel));

        [HttpGet(nameof(GetSpecializationsInfo))]
        public IActionResult GetSpecializationsInfo([FromQuery] SieveModel sieveModel) => Ok(_specializationService.Get(sieveModel, includeProperties: "Qualification"));

        [HttpPost(nameof(CreateSpecialization))]
        [DisplayActionName(DisplayName = "إنشاء اختصاص علمي جديد")]
        public async Task<IActionResult> CreateSpecialization(SpecializationDto specialization)
        {
            if (ModelState.IsValid)
            {
                await _specializationService.Add(specialization);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=specialization };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateSpecialization))]
        [DisplayActionName(DisplayName = "تعديل الاختصاص العلمي")]
        public async Task<IActionResult> UpdateSpecialization(SpecializationDto specialization)
        {
            if (ModelState.IsValid)
            {
                await _specializationService.Update(specialization);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = specialization };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteSpecialization))]
        [DisplayActionName(DisplayName = "حذف الاختصاص العلمي")]
        public async Task<IActionResult> DeleteSpecialization(Guid id)
        {
            if (ModelState.IsValid)
            {
                _specializationService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
