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
    public class FinancialImpactController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FinancialImpactController> _logger;
        private readonly IFinancialImpactService _financialimpactService;
        public FinancialImpactController(IUnitOfWork unitOfWork, ILogger<FinancialImpactController> logger, IFinancialImpactService financialimpactService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _financialimpactService = financialimpactService;
        }
        // GET: api/<FinancialImpacts>
        [HttpGet(nameof(GetFinancialImpacts))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetFinancialImpacts([FromQuery]SieveModel sieveModel) => Ok(_financialimpactService.GetAll(sieveModel));

        [HttpPost(nameof(CreateFinancialImpact))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateFinancialImpact(FinancialImpactDto financialimpact)
        {
            if (ModelState.IsValid)
            {
                await _financialimpactService.Add(financialimpact);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=financialimpact };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateFinancialImpact))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateFinancialImpact(FinancialImpactDto financialimpact)
        {
            if (ModelState.IsValid)
            {
                await _financialimpactService.Update(financialimpact);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = financialimpact };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteFinancialImpact))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteFinancialImpact(Guid id)
        {
            if (ModelState.IsValid)
            {
                _financialimpactService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
