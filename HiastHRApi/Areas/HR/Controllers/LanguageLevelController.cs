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
    public class LanguageLevelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LanguageLevelController> _logger;
        private readonly ILanguageLevelService _languagelevelService;
        public LanguageLevelController(IUnitOfWork unitOfWork, ILogger<LanguageLevelController> logger, ILanguageLevelService languagelevelService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _languagelevelService = languagelevelService;
        }
        // GET: api/<LanguageLevels>
        [HttpGet(nameof(GetLanguageLevels))]
        [DisplayActionName(DisplayName = "استعلام مستويات اللغة")]
        public IActionResult GetLanguageLevels([FromQuery]SieveModel sieveModel) => Ok(_languagelevelService.GetAll(sieveModel));

        [HttpPost(nameof(CreateLanguageLevel))]
        [DisplayActionName(DisplayName = "إنشاء مستوى لغة جديد")]
        public async Task<IActionResult> CreateLanguageLevel(LanguageLevelDto languagelevel)
        {
            if (ModelState.IsValid)
            {
                await _languagelevelService.Add(languagelevel);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=languagelevel };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateLanguageLevel))]
        [DisplayActionName(DisplayName = "تعديل مستوى اللغة")]
        public async Task<IActionResult> UpdateLanguageLevel(LanguageLevelDto languagelevel)
        {
            if (ModelState.IsValid)
            {
                await _languagelevelService.Update(languagelevel);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = languagelevel };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteLanguageLevel))]
        [DisplayActionName(DisplayName = "حذف مستوى اللغة")]
        public async Task<IActionResult> DeleteLanguageLevel(Guid id)
        {
            if (ModelState.IsValid)
            {
                _languagelevelService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
