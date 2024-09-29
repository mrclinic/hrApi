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
    public class EmpMilitaryServiceSuspensionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpMilitaryServiceSuspensionController> _logger;
        private readonly IEmpMilitaryServiceSuspensionService _empmilitaryservicesuspensionService;
        public EmpMilitaryServiceSuspensionController(IUnitOfWork unitOfWork, ILogger<EmpMilitaryServiceSuspensionController> logger, IEmpMilitaryServiceSuspensionService empmilitaryservicesuspensionService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empmilitaryservicesuspensionService = empmilitaryservicesuspensionService;
        }
        // GET: api/<EmpMilitaryServiceSuspensions>
        [HttpGet(nameof(GetEmpMilitaryServiceSuspensions))]
        [DisplayActionName(DisplayName = "استعلام ايقاف الخدمة الالزامية")]
        public IActionResult GetEmpMilitaryServiceSuspensions([FromQuery]SieveModel sieveModel) => Ok(_empmilitaryservicesuspensionService.GetAll(sieveModel));

        [HttpGet(nameof(GetEmpMilitaryServiceSuspensionsInfo))]
        [DisplayActionName(DisplayName = "استعلام ايقاف الخدمة الالزامية وتفاصيلها")]
        public IActionResult GetEmpMilitaryServiceSuspensionsInfo([FromQuery] SieveModel sieveModel) => Ok(_empmilitaryservicesuspensionService.Get(sieveModel));


        [HttpPost(nameof(CreateEmpMilitaryServiceSuspension))]
        [DisplayActionName(DisplayName = "ةإنشاء إيقاف خدمة إلزامية جديد")]
        public async Task<IActionResult> CreateEmpMilitaryServiceSuspension(EmpMilitaryServiceSuspensionDto empmilitaryservicesuspension)
        {
            if (ModelState.IsValid)
            {
                await _empmilitaryservicesuspensionService.Add(empmilitaryservicesuspension);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=empmilitaryservicesuspension };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpMilitaryServiceSuspension))]
        [DisplayActionName(DisplayName = "تعديل إيقاف خدمة إلزامية")]
        public async Task<IActionResult> UpdateEmpMilitaryServiceSuspension(EmpMilitaryServiceSuspensionDto empmilitaryservicesuspension)
        {
            if (ModelState.IsValid)
            {
                await _empmilitaryservicesuspensionService.Update(empmilitaryservicesuspension);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empmilitaryservicesuspension };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpMilitaryServiceSuspension))]
        [DisplayActionName(DisplayName = "حذف إيقاف خدمة إلزامية")]
        public async Task<IActionResult> DeleteEmpMilitaryServiceSuspension(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empmilitaryservicesuspensionService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
