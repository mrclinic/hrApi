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
    public class DeputationTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeputationTypeController> _logger;
        private readonly IDeputationTypeService _deputationtypeService;
        public DeputationTypeController(IUnitOfWork unitOfWork, ILogger<DeputationTypeController> logger, IDeputationTypeService deputationtypeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _deputationtypeService = deputationtypeService;
        }
        // GET: api/<DeputationTypes>
        [HttpGet(nameof(GetDeputationTypes))]
        [DisplayActionName(DisplayName = "استعلام أنواع الإيفاد")]
        public IActionResult GetDeputationTypes([FromQuery]SieveModel sieveModel) => Ok(_deputationtypeService.GetAll(sieveModel));

        [HttpPost(nameof(CreateDeputationType))]
        [DisplayActionName(DisplayName = "إنشاء نوع إيفاد جديد")]
        public async Task<IActionResult> CreateDeputationType(DeputationTypeDto deputationtype)
        {
            if (ModelState.IsValid)
            {
                await _deputationtypeService.Add(deputationtype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=deputationtype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateDeputationType))]
        [DisplayActionName(DisplayName = "تعديل نوع الإيفاد")]
        public async Task<IActionResult> UpdateDeputationType(DeputationTypeDto deputationtype)
        {
            if (ModelState.IsValid)
            {
                await _deputationtypeService.Update(deputationtype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = deputationtype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteDeputationType))]
        [DisplayActionName(DisplayName = "حذف نوع الإيفاد")]
        public async Task<IActionResult> DeleteDeputationType(Guid id)
        {
            if (ModelState.IsValid)
            {
                _deputationtypeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
