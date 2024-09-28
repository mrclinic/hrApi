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
    public class EmpPunishmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpPunishmentController> _logger;
        private readonly IEmpPunishmentService _emppunishmentService;
        public EmpPunishmentController(IUnitOfWork unitOfWork, ILogger<EmpPunishmentController> logger, IEmpPunishmentService emppunishmentService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emppunishmentService = emppunishmentService;
        }
        // GET: api/<EmpPunishments>
        [HttpGet(nameof(GetEmpPunishments))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetEmpPunishments([FromQuery]SieveModel sieveModel) => Ok(_emppunishmentService.GetAll(sieveModel));
        [HttpGet(nameof(GetEmpPunishmentsInfo))]
        public IActionResult GetEmpPunishmentsInfo([FromQuery] SieveModel sieveModel) => Ok(_emppunishmentService.Get(sieveModel, includeProperties: "IssuingDepartment,OrderDepartment,ContractType,PunishmentType"));

        [HttpPost(nameof(CreateEmpPunishment))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateEmpPunishment(EmpPunishmentDto emppunishment)
        {
            if (ModelState.IsValid)
            {
                await _emppunishmentService.Add(emppunishment);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=emppunishment };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpPunishment))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateEmpPunishment(EmpPunishmentDto emppunishment)
        {
            if (ModelState.IsValid)
            {
                await _emppunishmentService.Update(emppunishment);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = emppunishment };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpPunishment))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteEmpPunishment(Guid id)
        {
            if (ModelState.IsValid)
            {
                _emppunishmentService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
