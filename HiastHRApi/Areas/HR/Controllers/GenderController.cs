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
    public class GenderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GenderController> _logger;
        private readonly IGenderService _genderService;
        public GenderController(IUnitOfWork unitOfWork, ILogger<GenderController> logger, IGenderService genderService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _genderService = genderService;
        }
        // GET: api/<Genders>
        [HttpGet(nameof(GetGenders))]
        [DisplayActionName(DisplayName ="استعلام ")]
        public IActionResult GetGenders([FromQuery]SieveModel sieveModel) => Ok(_genderService.GetAll(sieveModel));

        [HttpPost(nameof(CreateGender))]
        [DisplayActionName(DisplayName = "إنشاء جنس جديد")]
        public async Task<IActionResult> CreateGender(GenderDto gender)
        {
            if (ModelState.IsValid)
            {
                await _genderService.Add(gender);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=gender };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateGender))]
        [DisplayActionName(DisplayName = "تعديل الجنس")]
        public async Task<IActionResult> UpdateGender(GenderDto gender)
        {
            if (ModelState.IsValid)
            {
                await _genderService.Update(gender);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = gender };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteGender))]
        [DisplayActionName(DisplayName = "حذف الجنس")]
        public async Task<IActionResult> DeleteGender(Guid id)
        {
            if (ModelState.IsValid)
            {
                _genderService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
