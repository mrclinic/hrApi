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
    public class EmpEmploymentStatusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpEmploymentStatusController> _logger;
        private readonly IEmpEmploymentStatusService _empemploymentstatusService;
        public EmpEmploymentStatusController(IUnitOfWork unitOfWork, ILogger<EmpEmploymentStatusController> logger, IEmpEmploymentStatusService empemploymentstatusService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empemploymentstatusService = empemploymentstatusService;
        }
        // GET: api/<EmpEmploymentStatuss>
        [HttpGet(nameof(GetEmpEmploymentStatuss))]
        [DisplayActionName(DisplayName = "استعلام فروع النقابة")]
        public IActionResult GetEmpEmploymentStatuss([FromQuery] SieveModel sieveModel) => Ok(_empemploymentstatusService.GetAll(sieveModel));

        [HttpGet(nameof(GetEmpEmploymentStatussInfo))]
        public IActionResult GetEmpEmploymentStatussInfo([FromQuery] SieveModel sieveModel) => Ok(_empemploymentstatusService.Get(sieveModel, includeProperties: "StartingType,ContractType"));


        [HttpPost(nameof(CreateEmpEmploymentStatus))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateEmpEmploymentStatus(EmpEmploymentStatusDto empemploymentstatus)
        {
            if (ModelState.IsValid)
            {
                await _empemploymentstatusService.Add(empemploymentstatus);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empemploymentstatus };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpEmploymentStatus))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateEmpEmploymentStatus(EmpEmploymentStatusDto empemploymentstatus)
        {
            if (ModelState.IsValid)
            {
                await _empemploymentstatusService.Update(empemploymentstatus);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empemploymentstatus };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpEmploymentStatus))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteEmpEmploymentStatus(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empemploymentstatusService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
