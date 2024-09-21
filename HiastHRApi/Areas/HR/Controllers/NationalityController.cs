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
    public class NationalityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<NationalityController> _logger;
        private readonly INationalityService _nationalityService;
        public NationalityController(IUnitOfWork unitOfWork, ILogger<NationalityController> logger, INationalityService nationalityService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _nationalityService = nationalityService;
        }
        // GET: api/<Nationalitys>
        [HttpGet(nameof(GetNationalitys))]
        [DisplayActionName(DisplayName = "استعلام الجنسيات")]
        public IActionResult GetNationalitys([FromQuery]SieveModel sieveModel) => Ok(_nationalityService.GetAll(sieveModel));

        [HttpPost(nameof(CreateNationality))]
        [DisplayActionName(DisplayName = "إنشاء جنسية جديدة")]
        public async Task<IActionResult> CreateNationality(NationalityDto nationality)
        {
            if (ModelState.IsValid)
            {
                await _nationalityService.Add(nationality);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=nationality };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateNationality))]
        [DisplayActionName(DisplayName = "تعديل الجنسية")]
        public async Task<IActionResult> UpdateNationality(NationalityDto nationality)
        {
            if (ModelState.IsValid)
            {
                await _nationalityService.Update(nationality);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = nationality };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteNationality))]
        [DisplayActionName(DisplayName = "حذف الجنسية")]
        public async Task<IActionResult> DeleteNationality(Guid id)
        {
            if (ModelState.IsValid)
            {
                _nationalityService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
