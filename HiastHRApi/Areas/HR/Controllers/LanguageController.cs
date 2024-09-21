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
    public class LanguageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LanguageController> _logger;
        private readonly ILanguageService _languageService;
        public LanguageController(IUnitOfWork unitOfWork, ILogger<LanguageController> logger, ILanguageService languageService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _languageService = languageService;
        }
        // GET: api/<Languages>
        [HttpGet(nameof(GetLanguages))]
        [DisplayActionName(DisplayName ="استعلام اللغات")]
        public IActionResult GetLanguages([FromQuery]SieveModel sieveModel) => Ok(_languageService.GetAll(sieveModel));

        [HttpPost(nameof(CreateLanguage))]
        [DisplayActionName(DisplayName = "ةإنشاء لغة جديد")]
        public async Task<IActionResult> CreateLanguage(LanguageDto language)
        {
            if (ModelState.IsValid)
            {
                await _languageService.Add(language);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=language };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateLanguage))]
        [DisplayActionName(DisplayName = "تعديل اللغة")]
        public async Task<IActionResult> UpdateLanguage(LanguageDto language)
        {
            if (ModelState.IsValid)
            {
                await _languageService.Update(language);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = language };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteLanguage))]
        [DisplayActionName(DisplayName = "حذف اللغة")]
        public async Task<IActionResult> DeleteLanguage(Guid id)
        {
            if (ModelState.IsValid)
            {
                _languageService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
