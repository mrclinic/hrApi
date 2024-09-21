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
    public class LawController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LawController> _logger;
        private readonly ILawService _lawService;
        public LawController(IUnitOfWork unitOfWork, ILogger<LawController> logger, ILawService lawService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _lawService = lawService;
        }
        // GET: api/<Laws>
        [HttpGet(nameof(GetLaws))]
        [DisplayActionName(DisplayName ="استعلام القوانين")]
        public IActionResult GetLaws([FromQuery]SieveModel sieveModel) => Ok(_lawService.GetAll(sieveModel));

        [HttpPost(nameof(CreateLaw))]
        [DisplayActionName(DisplayName = "إنشاء قانون جديد")]
        public async Task<IActionResult> CreateLaw(LawDto law)
        {
            if (ModelState.IsValid)
            {
                await _lawService.Add(law);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=law };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateLaw))]
        [DisplayActionName(DisplayName = "تعديل القانون")]
        public async Task<IActionResult> UpdateLaw(LawDto law)
        {
            if (ModelState.IsValid)
            {
                await _lawService.Update(law);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = law };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteLaw))]
        [DisplayActionName(DisplayName = "حذف القانون")]
        public async Task<IActionResult> DeleteLaw(Guid id)
        {
            if (ModelState.IsValid)
            {
                _lawService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
