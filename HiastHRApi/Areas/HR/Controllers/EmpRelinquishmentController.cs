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
    public class EmpRelinquishmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpRelinquishmentController> _logger;
        private readonly IEmpRelinquishmentService _emprelinquishmentService;
        public EmpRelinquishmentController(IUnitOfWork unitOfWork, ILogger<EmpRelinquishmentController> logger, IEmpRelinquishmentService emprelinquishmentService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emprelinquishmentService = emprelinquishmentService;
        }
        // GET: api/<EmpRelinquishments>
        [HttpGet(nameof(GetEmpRelinquishments))]
        [DisplayActionName(DisplayName = "استعلام الانفكاكات")]
        public IActionResult GetEmpRelinquishments([FromQuery]SieveModel sieveModel) => Ok(_emprelinquishmentService.GetAll(sieveModel));

        [HttpGet(nameof(GetEmpRelinquishmentsInfo))]
        [DisplayActionName(DisplayName = "استعلام الانفكاكات وتفاصيلها")]
        public IActionResult GetEmpRelinquishmentsInfo([FromQuery] SieveModel sieveModel) => Ok(_emprelinquishmentService.Get(sieveModel, includeProperties: "ContractType,RelinquishmentReason"));

        [HttpPost(nameof(CreateEmpRelinquishment))]
        [DisplayActionName(DisplayName = "إنشاء انفكاك جديد")]
        public async Task<IActionResult> CreateEmpRelinquishment(EmpRelinquishmentDto emprelinquishment)
        {
            if (ModelState.IsValid)
            {
                await _emprelinquishmentService.Add(emprelinquishment);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=emprelinquishment };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpRelinquishment))]
        [DisplayActionName(DisplayName = "تعديل انفكاك")]
        public async Task<IActionResult> UpdateEmpRelinquishment(EmpRelinquishmentDto emprelinquishment)
        {
            if (ModelState.IsValid)
            {
                await _emprelinquishmentService.Update(emprelinquishment);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = emprelinquishment };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpRelinquishment))]
        [DisplayActionName(DisplayName = "حذف انفكاك")]
        public async Task<IActionResult> DeleteEmpRelinquishment(Guid id)
        {
            if (ModelState.IsValid)
            {
                _emprelinquishmentService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
