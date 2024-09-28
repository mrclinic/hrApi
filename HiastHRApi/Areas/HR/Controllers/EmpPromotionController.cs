using hiastHRApi.Authorization;
using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Service.DTO.Employee;
using hiastHRApi.Service.IService.Employee;
using hiastHRApi.Service.Service.Employee;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;


namespace hiastHRApi.Areas.HR.Controllers
{
    [Area("HR")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class EmpPromotionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpPromotionController> _logger;
        private readonly IEmpPromotionService _emppromotionService;
        public EmpPromotionController(IUnitOfWork unitOfWork, ILogger<EmpPromotionController> logger, IEmpPromotionService emppromotionService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emppromotionService = emppromotionService;
        }
        // GET: api/<EmpPromotions>
        [HttpGet(nameof(GetEmpPromotions))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetEmpPromotions([FromQuery]SieveModel sieveModel) => Ok(_emppromotionService.GetAll(sieveModel));
        [HttpGet(nameof(GetEmpPromotionsInfo))]
        public IActionResult GetEmpPromotionsInfo([FromQuery] SieveModel sieveModel) => Ok(_emppromotionService.Get(sieveModel, includeProperties: "EvaluationGrade,PromotionPercentage"));

        [HttpPost(nameof(CreateEmpPromotion))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateEmpPromotion(EmpPromotionDto emppromotion)
        {
            if (ModelState.IsValid)
            {
                await _emppromotionService.Add(emppromotion);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=emppromotion };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpPromotion))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateEmpPromotion(EmpPromotionDto emppromotion)
        {
            if (ModelState.IsValid)
            {
                await _emppromotionService.Update(emppromotion);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = emppromotion };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpPromotion))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteEmpPromotion(Guid id)
        {
            if (ModelState.IsValid)
            {
                _emppromotionService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
