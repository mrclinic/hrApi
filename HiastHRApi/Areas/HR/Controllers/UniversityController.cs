
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
    public class UniversityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UniversityController> _logger;
        private readonly IUniversityService _UniversityService;
        public UniversityController(IUnitOfWork unitOfWork, ILogger<UniversityController> logger, IUniversityService UniversityService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _UniversityService = UniversityService;
        }
        // GET: api/<Universitys>
        [HttpGet(nameof(GetUniversitys))]
        [DisplayActionName(DisplayName = "استعلام الجامعات")]
        public IActionResult GetUniversitys([FromQuery] SieveModel sieveModel) => Ok(_UniversityService.GetAll(sieveModel));

        [HttpGet(nameof(GetUniversitysInfo))]
        [DisplayActionName(DisplayName = "استعلام الجامعات وتفاصيلها")]
        public IActionResult GetUniversitysInfo([FromQuery] SieveModel sieveModel) => Ok(_UniversityService.Get(sieveModel, includeProperties: "Country"));

        [HttpPost(nameof(CreateUniversity))]
        [DisplayActionName(DisplayName = "إنشاء جامعة جديد")]
        public async Task<IActionResult> CreateUniversity(UniversityDto University)
        {
            if (ModelState.IsValid)
            {
                await _UniversityService.Add(University);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = University };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateUniversity))]
        [DisplayActionName(DisplayName = "تعديل جامعة")]
        public async Task<IActionResult> UpdateUniversity(UniversityDto University)
        {
            if (ModelState.IsValid)
            {
                await _UniversityService.Update(University);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = University };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteUniversity))]
        [DisplayActionName(DisplayName = "حذف جامعة")]
        public async Task<IActionResult> DeleteUniversity(Guid id)
        {
            if (ModelState.IsValid)
            {
                _UniversityService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
