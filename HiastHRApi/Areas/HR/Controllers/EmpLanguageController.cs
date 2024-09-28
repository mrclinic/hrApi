using hiastHRApi.Authorization;
using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Service.DTO.Employee;
using hiastHRApi.Service.IService.Employee;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;


namespace hiastHRApi.Areas.HR.Controllers
{
    [Area("HR")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class EmpLanguageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpLanguageController> _logger;
        private readonly IEmpLanguageService _emplanguageService;
        public EmpLanguageController(IUnitOfWork unitOfWork, ILogger<EmpLanguageController> logger, IEmpLanguageService emplanguageService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emplanguageService = emplanguageService;
        }
        // GET: api/<EmpLanguages>
        [HttpGet(nameof(GetEmpLanguages))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetEmpLanguages([FromQuery]SieveModel sieveModel) => Ok(_emplanguageService.GetAll(sieveModel));

        [HttpGet(nameof(GetEmpLanguagesInfo))]
        public IActionResult GetEmpLanguagesInfo([FromQuery] SieveModel sieveModel) => Ok(_emplanguageService.Get(sieveModel, includeProperties: "LanguageLevel,Language"));

        [HttpPost(nameof(CreateEmpLanguage))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateEmpLanguage(EmpLanguageDto emplanguage)
        {
            if (ModelState.IsValid)
            {
                await _emplanguageService.Add(emplanguage);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=emplanguage };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpLanguage))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateEmpLanguage(EmpLanguageDto emplanguage)
        {
            if (ModelState.IsValid)
            {
                await _emplanguageService.Update(emplanguage);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = emplanguage };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpLanguage))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteEmpLanguage(Guid id)
        {
            if (ModelState.IsValid)
            {
                _emplanguageService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
