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
    public class VacationTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<VacationTypeController> _logger;
        private readonly IVacationTypeService _vacationtypeService;
        public VacationTypeController(IUnitOfWork unitOfWork, ILogger<VacationTypeController> logger, IVacationTypeService vacationtypeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _vacationtypeService = vacationtypeService;
        }
        // GET: api/<VacationTypes>
        [HttpGet(nameof(GetVacationTypes))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetVacationTypes([FromQuery]SieveModel sieveModel) => Ok(_vacationtypeService.GetAll(sieveModel));

        [HttpPost(nameof(CreateVacationType))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateVacationType(VacationTypeDto vacationtype)
        {
            if (ModelState.IsValid)
            {
                await _vacationtypeService.Add(vacationtype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=vacationtype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateVacationType))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateVacationType(VacationTypeDto vacationtype)
        {
            if (ModelState.IsValid)
            {
                await _vacationtypeService.Update(vacationtype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = vacationtype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteVacationType))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteVacationType(Guid id)
        {
            if (ModelState.IsValid)
            {
                _vacationtypeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
