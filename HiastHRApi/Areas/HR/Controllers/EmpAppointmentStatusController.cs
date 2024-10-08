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
    public class EmpAppointmentStatusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpAppointmentStatusController> _logger;
        private readonly IEmpAppointmentStatusService _empappointmentstatusService;
        public EmpAppointmentStatusController(IUnitOfWork unitOfWork, ILogger<EmpAppointmentStatusController> logger, IEmpAppointmentStatusService empappointmentstatusService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empappointmentstatusService = empappointmentstatusService;
        }
        // GET: api/<EmpAppointmentStatuss>
        [HttpGet(nameof(GetEmpAppointmentStatuss))]
        [DisplayActionName(DisplayName = "استعلام أنواع الأوضاع الوظيفية")]
        public IActionResult GetEmpAppointmentStatuss([FromQuery] SieveModel sieveModel) => Ok(_empappointmentstatusService.GetAll(sieveModel));

        [HttpGet(nameof(GetEmpAppointmentStatussInfo))]
        [DisplayActionName(DisplayName = "استعلام أنواع الأوضاع الوظيفية وتفاصيلها")]
        public IActionResult GetEmpAppointmentStatussInfo([FromQuery] SieveModel sieveModel) => Ok(_empappointmentstatusService.Get(sieveModel, includeProperties: "InsuranceSystem,AppointmentContractType,HealthyStatus,DisabilityType,JobCategory,ModificationContractType,StartingType,Law"));

        [HttpPost(nameof(CreateEmpAppointmentStatus))]
        [DisplayActionName(DisplayName = "إنشاء نوع وضع وظيفي جديد")]
        public async Task<IActionResult> CreateEmpAppointmentStatus(EmpAppointmentStatusDto empappointmentstatus)
        {
            if (ModelState.IsValid)
            {
                await _empappointmentstatusService.Add(empappointmentstatus);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empappointmentstatus };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpAppointmentStatus))]
        [DisplayActionName(DisplayName = "تعديل نوع الوضع الوظيفي")]
        public async Task<IActionResult> UpdateEmpAppointmentStatus(EmpAppointmentStatusDto empappointmentstatus)
        {
            if (ModelState.IsValid)
            {
                await _empappointmentstatusService.Update(empappointmentstatus);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empappointmentstatus };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpAppointmentStatus))]
        [DisplayActionName(DisplayName = "حذف نوع الوضع الوظيفي")]
        public async Task<IActionResult> DeleteEmpAppointmentStatus(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empappointmentstatusService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
