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
    public class ChildStatusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ChildStatusController> _logger;
        private readonly IChildStatusService _childstatusService;
        public ChildStatusController(IUnitOfWork unitOfWork, ILogger<ChildStatusController> logger, IChildStatusService childstatusService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _childstatusService = childstatusService;
        }
        // GET: api/<ChildStatuss>
        [HttpGet(nameof(GetChildStatuss))]
        [DisplayActionName(DisplayName ="استعلام حالات الطفل")]
        public IActionResult GetChildStatuss([FromQuery]SieveModel sieveModel) => Ok(_childstatusService.GetAll(sieveModel));

        [HttpPost(nameof(CreateChildStatus))]
        [DisplayActionName(DisplayName = "إنشاء حالة الطفل جديدة")]
        public async Task<IActionResult> CreateChildStatus(ChildStatusDto childstatus)
        {
            if (ModelState.IsValid)
            {
                await _childstatusService.Add(childstatus);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=childstatus };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateChildStatus))]
        [DisplayActionName(DisplayName = "تعديل حالة الطفل")]
        public async Task<IActionResult> UpdateChildStatus(ChildStatusDto childstatus)
        {
            if (ModelState.IsValid)
            {
                await _childstatusService.Update(childstatus);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = childstatus };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteChildStatus))]
        [DisplayActionName(DisplayName = "حذف حالة الطفل")]
        public async Task<IActionResult> DeleteChildStatus(Guid id)
        {
            if (ModelState.IsValid)
            {
                _childstatusService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
