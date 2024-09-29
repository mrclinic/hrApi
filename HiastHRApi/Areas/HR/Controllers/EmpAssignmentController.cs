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
    public class EmpAssignmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpAssignmentController> _logger;
        private readonly IEmpAssignmentService _empassignmentService;
        public EmpAssignmentController(IUnitOfWork unitOfWork, ILogger<EmpAssignmentController> logger, IEmpAssignmentService empassignmentService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empassignmentService = empassignmentService;
        }
        // GET: api/<EmpAssignments>
        [HttpGet(nameof(GetEmpAssignments))]
        [DisplayActionName(DisplayName = "استعلام الأعمال والتكاليف")]
        public IActionResult GetEmpAssignments([FromQuery]SieveModel sieveModel) => Ok(_empassignmentService.GetAll(sieveModel));

        [HttpGet(nameof(GetEmpAssignmentsInfo))]
        [DisplayActionName(DisplayName = "استعلام الأعمال والتكاليف وتفاصيلها")]
        public IActionResult GetEmpAssignmentsInfo([FromQuery] SieveModel sieveModel) => Ok(_empassignmentService.Get(sieveModel, includeProperties: "ContractType"));


        [HttpPost(nameof(CreateEmpAssignment))]
        [DisplayActionName(DisplayName = "إنشاء عمل وتكليف جديد")]
        public async Task<IActionResult> CreateEmpAssignment(EmpAssignmentDto empassignment)
        {
            if (ModelState.IsValid)
            {
                await _empassignmentService.Add(empassignment);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=empassignment };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpAssignment))]
        [DisplayActionName(DisplayName = "تعديل عمل أو تكليف")]
        public async Task<IActionResult> UpdateEmpAssignment(EmpAssignmentDto empassignment)
        {
            if (ModelState.IsValid)
            {
                await _empassignmentService.Update(empassignment);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empassignment };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpAssignment))]
        [DisplayActionName(DisplayName = "حذف عمل أو تكليف")]
        public async Task<IActionResult> DeleteEmpAssignment(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empassignmentService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
