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
    public class ModificationContractTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ModificationContractTypeController> _logger;
        private readonly IModificationContractTypeService _modificationcontracttypeService;
        public ModificationContractTypeController(IUnitOfWork unitOfWork, ILogger<ModificationContractTypeController> logger, IModificationContractTypeService modificationcontracttypeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _modificationcontracttypeService = modificationcontracttypeService;
        }
        // GET: api/<ModificationContractTypes>
        [HttpGet(nameof(GetModificationContractTypes))]
        [DisplayActionName(DisplayName = "استعلام أنواع صكوك التعيين المعدل")]
        public IActionResult GetModificationContractTypes([FromQuery]SieveModel sieveModel) => Ok(_modificationcontracttypeService.GetAll(sieveModel));

        [HttpPost(nameof(CreateModificationContractType))]
        [DisplayActionName(DisplayName = "إنشاء نوع صكوك تعيين معدل جديد")]
        public async Task<IActionResult> CreateModificationContractType(ModificationContractTypeDto modificationcontracttype)
        {
            if (ModelState.IsValid)
            {
                await _modificationcontracttypeService.Add(modificationcontracttype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=modificationcontracttype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateModificationContractType))]
        [DisplayActionName(DisplayName = "تعديل نوع صكوك التعيين المعدل")]
        public async Task<IActionResult> UpdateModificationContractType(ModificationContractTypeDto modificationcontracttype)
        {
            if (ModelState.IsValid)
            {
                await _modificationcontracttypeService.Update(modificationcontracttype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = modificationcontracttype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteModificationContractType))]
        [DisplayActionName(DisplayName = "حذف نوع صكوك التعيين المعدل")]
        public async Task<IActionResult> DeleteModificationContractType(Guid id)
        {
            if (ModelState.IsValid)
            {
                _modificationcontracttypeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
