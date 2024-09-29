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
        [DisplayActionName(DisplayName ="استعلام المكافآت")]
        public IActionResult GetEmpRewards([FromQuery]SieveModel sieveModel) => Ok(_emprewardService.GetAll(sieveModel));
        [HttpGet(nameof(GetEmpRewardsInfo))]
        [DisplayActionName(DisplayName = "استعلام المكافآت وتفاصيلها")]
        public IActionResult GetEmpRewardsInfo([FromQuery] SieveModel sieveModel) => Ok(_emprewardService.Get(sieveModel, includeProperties: "ContractType,OrgDepartment,FinancialIndicatorType,RewardType"));

        [HttpPost(nameof(CreateEmpReward))]
        [DisplayActionName(DisplayName = "إنشاء مكافآة جديدة")]
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
        [DisplayActionName(DisplayName = "تعديل مكافآة")]
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
        [DisplayActionName(DisplayName = "حذف مكافآة")]
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
