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
    public class EmpChildController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpChildController> _logger;
        private readonly IEmpChildService _empchildService;
        public EmpChildController(IUnitOfWork unitOfWork, ILogger<EmpChildController> logger, IEmpChildService empchildService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empchildService = empchildService;
        }
        // GET: api/<EmpChilds>
        [HttpGet(nameof(GetEmpChilds))]
        [DisplayActionName(DisplayName = "استعلام الابناء")]
        public IActionResult GetEmpChilds([FromQuery]SieveModel sieveModel) => Ok(_empchildService.GetAll(sieveModel));
        [HttpGet(nameof(GetEmpChildsInfo))]
        [DisplayActionName(DisplayName = "استعلام الابناء وتفاصيلها")]
        public IActionResult GetEmpChildsInfo([FromQuery] SieveModel sieveModel) => Ok(_empchildService.Get(sieveModel, includeProperties: "Gender,Status"));

        [HttpPost(nameof(CreateEmpChild))]
        [DisplayActionName(DisplayName = "إنشاء ابن جديد")]
        public async Task<IActionResult> CreateEmpChild(EmpChildDto empchild)
        {
            if (ModelState.IsValid)
            {
                await _empchildService.Add(empchild);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=empchild };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpChild))]
        [DisplayActionName(DisplayName = "تعديل ابن")]
        public async Task<IActionResult> UpdateEmpChild(EmpChildDto empchild)
        {
            if (ModelState.IsValid)
            {
                await _empchildService.Update(empchild);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empchild };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpChild))]
        [DisplayActionName(DisplayName = "حذف ابن")]
        public async Task<IActionResult> DeleteEmpChild(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empchildService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
