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
    public class BranchController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BranchController> _logger;
        private readonly IBranchService _branchService;
        public BranchController(IUnitOfWork unitOfWork, ILogger<BranchController> logger, IBranchService branchService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _branchService = branchService;
        }
        // GET: api/<Branchs>
        [HttpGet(nameof(GetBranchs))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetBranchs([FromQuery]SieveModel sieveModel) => Ok(_branchService.GetAll(sieveModel));

        [HttpPost(nameof(CreateBranch))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateBranch(BranchDto branch)
        {
            if (ModelState.IsValid)
            {
                await _branchService.Add(branch);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=branch };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateBranch))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateBranch(BranchDto branch)
        {
            if (ModelState.IsValid)
            {
                await _branchService.Update(branch);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = branch };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteBranch))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteBranch(Guid id)
        {
            if (ModelState.IsValid)
            {
                _branchService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
