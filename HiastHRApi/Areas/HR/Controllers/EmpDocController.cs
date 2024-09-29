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
    public class EmpDocController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpDocController> _logger;
        private readonly IEmpDocService _empDocService;
        public EmpDocController(IUnitOfWork unitOfWork, ILogger<EmpDocController> logger, IEmpDocService empDocService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empDocService = empDocService;
        }
        // GET: api/<EmpDocs>
        [HttpGet(nameof(GetEmpDocs))]
        [DisplayActionName(DisplayName = "استعلام وثائق الموظفين")]
        public IActionResult GetEmpDocs([FromQuery]SieveModel sieveModel) => Ok(_empDocService.GetAll(sieveModel));
        [HttpGet(nameof(GetEmpDocsInfo))]
        [DisplayActionName(DisplayName = "استعلام وثائق الموظفين وتفاصيلها")]
        public IActionResult GetEmpDocsInfo([FromQuery] SieveModel sieveModel) => Ok(_empDocService.Get(sieveModel, includeProperties: "DocType"));

        [HttpPost(nameof(CreateEmpDoc))]
        [DisplayActionName(DisplayName = "إنشاء وثيقة موظف جديدة")]
        public async Task<IActionResult> CreateEmpDoc(EmpDocDto empDoc)
        {
            if (ModelState.IsValid)
            {
                await _empDocService.Add(empDoc);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=empDoc };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpDoc))]
        [DisplayActionName(DisplayName = "تعديل وثيقة موظف")]
        public async Task<IActionResult> UpdateEmpDoc(EmpDocDto empDoc)
        {
            if (ModelState.IsValid)
            {
                await _empDocService.Update(empDoc);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empDoc };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpDoc))]
        [DisplayActionName(DisplayName = "حذف وثيقة موظف")]
        public async Task<IActionResult> DeleteEmpDoc(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empDocService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
