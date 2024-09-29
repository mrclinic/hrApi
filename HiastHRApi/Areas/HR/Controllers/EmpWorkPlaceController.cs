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
    public class EmpWorkPlaceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpWorkPlaceController> _logger;
        private readonly IEmpWorkPlaceService _empworkplaceService;
        public EmpWorkPlaceController(IUnitOfWork unitOfWork, ILogger<EmpWorkPlaceController> logger, IEmpWorkPlaceService empworkplaceService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empworkplaceService = empworkplaceService;
        }
        // GET: api/<EmpWorkPlaces>
        [HttpGet(nameof(GetEmpWorkPlaces))]
        [DisplayActionName(DisplayName = "استعلام أماكن العمل")]
        public IActionResult GetEmpWorkPlaces([FromQuery]SieveModel sieveModel) => Ok(_empworkplaceService.GetAll(sieveModel));

        [HttpGet(nameof(GetEmpWorkPlacesInfo))]
        [DisplayActionName(DisplayName = "استعلام أماكن العمل وتفاصيلها")]
        public IActionResult GetEmpWorkPlacesInfo([FromQuery] SieveModel sieveModel) => Ok(_empworkplaceService.Get(sieveModel, includeProperties: "ContractType"));

        [HttpPost(nameof(CreateEmpWorkPlace))]
        [DisplayActionName(DisplayName = "إنشاء مكان عمل جديد")]
        public async Task<IActionResult> CreateEmpWorkPlace(EmpWorkPlaceDto empworkplace)
        {
            if (ModelState.IsValid)
            {
                await _empworkplaceService.Add(empworkplace);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=empworkplace };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpWorkPlace))]
        [DisplayActionName(DisplayName = "تعديل مكان عمل")]
        public async Task<IActionResult> UpdateEmpWorkPlace(EmpWorkPlaceDto empworkplace)
        {
            if (ModelState.IsValid)
            {
                await _empworkplaceService.Update(empworkplace);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empworkplace };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpWorkPlace))]
        [DisplayActionName(DisplayName = "حذف مكان عمل")]
        public async Task<IActionResult> DeleteEmpWorkPlace(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empworkplaceService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
