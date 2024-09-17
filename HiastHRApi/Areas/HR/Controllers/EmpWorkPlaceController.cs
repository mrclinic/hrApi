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
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetEmpWorkPlaces([FromQuery]SieveModel sieveModel) => Ok(_empworkplaceService.GetAll(sieveModel));

        [HttpPost(nameof(CreateEmpWorkPlace))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
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
        [DisplayActionName(DisplayName = "تعديل فرع")]
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
        [DisplayActionName(DisplayName = "حذف فرع")]
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
