using hiastHRApi.Authorization;
using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Service.IService.Constants;
using hiastHRApi.Service.Service.Constants;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;


namespace hiastHRApi.Areas.HR.Controllers
{
    [Area("HR")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class PunishmentTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PunishmentTypeController> _logger;
        private readonly IPunishmentTypeService _punishmenttypeService;
        public PunishmentTypeController(IUnitOfWork unitOfWork, ILogger<PunishmentTypeController> logger, IPunishmentTypeService punishmenttypeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _punishmenttypeService = punishmenttypeService;
        }
        // GET: api/<PunishmentTypes>
        [HttpGet(nameof(GetPunishmentTypes))]
        [DisplayActionName(DisplayName = "استعلام أنواع العقوبات")]
        public IActionResult GetPunishmentTypes([FromQuery]SieveModel sieveModel) => Ok(_punishmenttypeService.GetAll(sieveModel));

        [HttpGet(nameof(GetPunishmentTypesInfo))]
        public IActionResult GetPunishmentTypesInfo([FromQuery] SieveModel sieveModel) => Ok(_punishmenttypeService.Get(sieveModel, includeProperties: "FinancialImpact"));

        [HttpPost(nameof(CreatePunishmentType))]
        [DisplayActionName(DisplayName = "إنشاء نوع عقوبة جديد")]
        public async Task<IActionResult> CreatePunishmentType(PunishmentTypeDto punishmenttype)
        {
            if (ModelState.IsValid)
            {
                await _punishmenttypeService.Add(punishmenttype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=punishmenttype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdatePunishmentType))]
        [DisplayActionName(DisplayName = "تعديل نوع العقوبة")]
        public async Task<IActionResult> UpdatePunishmentType(PunishmentTypeDto punishmenttype)
        {
            if (ModelState.IsValid)
            {
                await _punishmenttypeService.Update(punishmenttype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = punishmenttype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeletePunishmentType))]
        [DisplayActionName(DisplayName = "حذف نوع العقوبة")]
        public async Task<IActionResult> DeletePunishmentType(Guid id)
        {
            if (ModelState.IsValid)
            {
                _punishmenttypeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
