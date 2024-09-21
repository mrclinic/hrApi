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
    public class EmpRewardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpRewardController> _logger;
        private readonly IEmpRewardService _emprewardService;
        public EmpRewardController(IUnitOfWork unitOfWork, ILogger<EmpRewardController> logger, IEmpRewardService emprewardService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emprewardService = emprewardService;
        }
        // GET: api/<EmpRewards>
        [HttpGet(nameof(GetEmpRewards))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetEmpRewards([FromQuery]SieveModel sieveModel) => Ok(_emprewardService.GetAll(sieveModel));

        [HttpPost(nameof(CreateEmpReward))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateEmpReward(EmpRewardDto empreward)
        {
            if (ModelState.IsValid)
            {
                await _emprewardService.Add(empreward);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=empreward };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpReward))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateEmpReward(EmpRewardDto empreward)
        {
            if (ModelState.IsValid)
            {
                await _emprewardService.Update(empreward);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = empreward };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpReward))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteEmpReward(Guid id)
        {
            if (ModelState.IsValid)
            {
                _emprewardService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
