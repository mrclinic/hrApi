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
    public class QualificationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<QualificationController> _logger;
        private readonly IQualificationService _qualificationService;
        public QualificationController(IUnitOfWork unitOfWork, ILogger<QualificationController> logger, IQualificationService qualificationService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _qualificationService = qualificationService;
        }
        // GET: api/<Qualifications>
        [HttpGet(nameof(GetQualifications))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetQualifications([FromQuery]SieveModel sieveModel) => Ok(_qualificationService.GetAll(sieveModel));

        [HttpPost(nameof(CreateQualification))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateQualification(QualificationDto qualification)
        {
            if (ModelState.IsValid)
            {
                await _qualificationService.Add(qualification);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=qualification };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateQualification))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateQualification(QualificationDto qualification)
        {
            if (ModelState.IsValid)
            {
                await _qualificationService.Update(qualification);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = qualification };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteQualification))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteQualification(Guid id)
        {
            if (ModelState.IsValid)
            {
                _qualificationService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
