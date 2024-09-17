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
    public class ForcedVacationTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ForcedVacationTypeController> _logger;
        private readonly IForcedVacationTypeService _forcedvacationtypeService;
        public ForcedVacationTypeController(IUnitOfWork unitOfWork, ILogger<ForcedVacationTypeController> logger, IForcedVacationTypeService forcedvacationtypeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _forcedvacationtypeService = forcedvacationtypeService;
        }
        // GET: api/<ForcedVacationTypes>
        [HttpGet(nameof(GetForcedVacationTypes))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetForcedVacationTypes([FromQuery]SieveModel sieveModel) => Ok(_forcedvacationtypeService.GetAll(sieveModel));

        [HttpPost(nameof(CreateForcedVacationType))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateForcedVacationType(ForcedVacationTypeDto forcedvacationtype)
        {
            if (ModelState.IsValid)
            {
                await _forcedvacationtypeService.Add(forcedvacationtype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=forcedvacationtype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateForcedVacationType))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateForcedVacationType(ForcedVacationTypeDto forcedvacationtype)
        {
            if (ModelState.IsValid)
            {
                await _forcedvacationtypeService.Update(forcedvacationtype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = forcedvacationtype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteForcedVacationType))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteForcedVacationType(Guid id)
        {
            if (ModelState.IsValid)
            {
                _forcedvacationtypeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
