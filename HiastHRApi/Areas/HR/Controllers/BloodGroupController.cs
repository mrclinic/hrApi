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
    public class BloodGroupController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BloodGroupController> _logger;
        private readonly IBloodGroupService _bloodgroupService;
        public BloodGroupController(IUnitOfWork unitOfWork, ILogger<BloodGroupController> logger, IBloodGroupService bloodgroupService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _bloodgroupService = bloodgroupService;
        }
        // GET: api/<BloodGroups>
        [HttpGet(nameof(GetBloodGroups))]
        [DisplayActionName(DisplayName = "استعلام الزمر الدموية")]
        public IActionResult GetBloodGroups([FromQuery] SieveModel sieveModel) => Ok(_bloodgroupService.GetAll(sieveModel));

        [HttpPost(nameof(CreateBloodGroup))]
        [DisplayActionName(DisplayName = "إنشاء زمرة جديدة")]
        public async Task<IActionResult> CreateBloodGroup(BloodGroupDto bloodgroup)
        {
            if (ModelState.IsValid)
            {
                await _bloodgroupService.Add(bloodgroup);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = bloodgroup };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateBloodGroup))]
        [DisplayActionName(DisplayName = "تعديل زمرة")]
        public async Task<IActionResult> UpdateBloodGroup(BloodGroupDto bloodgroup)
        {
            if (ModelState.IsValid)
            {
                await _bloodgroupService.Update(bloodgroup);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = bloodgroup };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteBloodGroup))]
        [DisplayActionName(DisplayName = "حذف زمرة")]
        public async Task<IActionResult> DeleteBloodGroup(Guid id)
        {
            if (ModelState.IsValid)
            {
                _bloodgroupService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
