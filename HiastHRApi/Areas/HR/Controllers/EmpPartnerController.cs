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
    public class EmpPartnerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpPartnerController> _logger;
        private readonly IEmpPartnerService _emppartnerService;
        public EmpPartnerController(IUnitOfWork unitOfWork, ILogger<EmpPartnerController> logger, IEmpPartnerService emppartnerService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emppartnerService = emppartnerService;
        }
        // GET: api/<EmpPartners>
        [HttpGet(nameof(GetEmpPartners))]
        [DisplayActionName(DisplayName = "استعلام الزوجات")]
        public IActionResult GetEmpPartners([FromQuery]SieveModel sieveModel) => Ok(_emppartnerService.GetAll(sieveModel));
        [HttpGet(nameof(GetEmpPartnersInfo))]
        [DisplayActionName(DisplayName = "استعلام الزوجات وتفاصيلها")]
        public IActionResult GetEmpPartnersInfo([FromQuery] SieveModel sieveModel) => Ok(_emppartnerService.Get(sieveModel, includeProperties: "Gender,Nationality,OccurrenceType,PartnerWork"));


        [HttpPost(nameof(CreateEmpPartner))]
        [DisplayActionName(DisplayName = "إنشاء زوجة جديدة")]
        public async Task<IActionResult> CreateEmpPartner(EmpPartnerDto emppartner)
        {
            if (ModelState.IsValid)
            {
                await _emppartnerService.Add(emppartner);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=emppartner };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpPartner))]
        [DisplayActionName(DisplayName = "تعديل زوجة")]
        public async Task<IActionResult> UpdateEmpPartner(EmpPartnerDto emppartner)
        {
            if (ModelState.IsValid)
            {
                await _emppartnerService.Update(emppartner);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = emppartner };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpPartner))]
        [DisplayActionName(DisplayName = "حذف زوجة")]
        public async Task<IActionResult> DeleteEmpPartner(Guid id)
        {
            if (ModelState.IsValid)
            {
                _emppartnerService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
