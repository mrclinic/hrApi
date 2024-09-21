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
    public class EmpMilitaryServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpMilitaryServiceController> _logger;
        private readonly IEmpMilitaryServiceService _empmilitaryserviceService;
        public EmpMilitaryServiceController(IUnitOfWork unitOfWork, ILogger<EmpMilitaryServiceController> logger, IEmpMilitaryServiceService empmilitaryserviceService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empmilitaryserviceService = empmilitaryserviceService;
        }
        // GET: api/<EmpMilitaryServices>
        [HttpGet(nameof(GetEmpMilitaryServices))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetEmpMilitaryServices([FromQuery]SieveModel sieveModel) => Ok(_empmilitaryserviceService.GetAll(sieveModel));

        [HttpPost(nameof(CreateEmpMilitaryService))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateEmpMilitaryService(EmpMilitaryServiceDto empmilitaryservice)
        {
            if (ModelState.IsValid)
            {
                await _empmilitaryserviceService.Add(empmilitaryservice);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=empmilitaryservice };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpMilitaryService))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateEmpMilitaryService(EmpMilitaryServiceDto empmilitaryservice)
        {
            if (ModelState.IsValid)
            {
                await _empmilitaryserviceService.Update(empmilitaryservice);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empmilitaryservice };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpMilitaryService))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteEmpMilitaryService(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empmilitaryserviceService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
