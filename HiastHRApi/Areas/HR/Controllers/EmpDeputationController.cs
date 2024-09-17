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
    public class EmpDeputationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpDeputationController> _logger;
        private readonly IEmpDeputationService _empdeputationService;
        public EmpDeputationController(IUnitOfWork unitOfWork, ILogger<EmpDeputationController> logger, IEmpDeputationService empdeputationService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _empdeputationService = empdeputationService;
        }
        // GET: api/<EmpDeputations>
        [HttpGet(nameof(GetEmpDeputations))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetEmpDeputations([FromQuery]SieveModel sieveModel) => Ok(_empdeputationService.GetAll(sieveModel));

        [HttpPost(nameof(CreateEmpDeputation))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateEmpDeputation(EmpDeputationDto empdeputation)
        {
            if (ModelState.IsValid)
            {
                await _empdeputationService.Add(empdeputation);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=empdeputation };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpDeputation))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateEmpDeputation(EmpDeputationDto empdeputation)
        {
            if (ModelState.IsValid)
            {
                await _empdeputationService.Update(empdeputation);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empdeputation };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpDeputation))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteEmpDeputation(Guid id)
        {
            if (ModelState.IsValid)
            {
                _empdeputationService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
