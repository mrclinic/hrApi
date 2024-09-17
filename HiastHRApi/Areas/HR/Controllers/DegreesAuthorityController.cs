using hiastHRApi.Authorization;
using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Service.IService.Constants;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;


namespace hiastHRApi.Areas.HR.Controllers
{
    [Area("HR")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class DegreesAuthorityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DegreesAuthorityController> _logger;
        private readonly IDegreesAuthorityService _degreesauthorityService;
        public DegreesAuthorityController(IUnitOfWork unitOfWork, ILogger<DegreesAuthorityController> logger, IDegreesAuthorityService degreesauthorityService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _degreesauthorityService = degreesauthorityService;
        }
        // GET: api/<DegreesAuthoritys>
        [HttpGet(nameof(GetDegreesAuthoritys))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetDegreesAuthoritys([FromQuery]SieveModel sieveModel) => Ok(_degreesauthorityService.GetAll(sieveModel));

        [HttpPost(nameof(CreateDegreesAuthority))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateDegreesAuthority(DegreesAuthorityDto degreesauthority)
        {
            if (ModelState.IsValid)
            {
                await _degreesauthorityService.Add(degreesauthority);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=degreesauthority };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateDegreesAuthority))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateDegreesAuthority(DegreesAuthorityDto degreesauthority)
        {
            if (ModelState.IsValid)
            {
                await _degreesauthorityService.Update(degreesauthority);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = degreesauthority };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteDegreesAuthority))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteDegreesAuthority(Guid id)
        {
            if (ModelState.IsValid)
            {
                _degreesauthorityService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
