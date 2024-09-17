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
    public class MilitarySpecializationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MilitarySpecializationController> _logger;
        private readonly IMilitarySpecializationService _militaryspecializationService;
        public MilitarySpecializationController(IUnitOfWork unitOfWork, ILogger<MilitarySpecializationController> logger, IMilitarySpecializationService militaryspecializationService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _militaryspecializationService = militaryspecializationService;
        }
        // GET: api/<MilitarySpecializations>
        [HttpGet(nameof(GetMilitarySpecializations))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetMilitarySpecializations([FromQuery]SieveModel sieveModel) => Ok(_militaryspecializationService.GetAll(sieveModel));

        [HttpPost(nameof(CreateMilitarySpecialization))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateMilitarySpecialization(MilitarySpecializationDto militaryspecialization)
        {
            if (ModelState.IsValid)
            {
                await _militaryspecializationService.Add(militaryspecialization);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=militaryspecialization };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateMilitarySpecialization))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateMilitarySpecialization(MilitarySpecializationDto militaryspecialization)
        {
            if (ModelState.IsValid)
            {
                await _militaryspecializationService.Update(militaryspecialization);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = militaryspecialization };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteMilitarySpecialization))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteMilitarySpecialization(Guid id)
        {
            if (ModelState.IsValid)
            {
                _militaryspecializationService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
