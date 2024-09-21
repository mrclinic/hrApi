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
    public class StartingTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StartingTypeController> _logger;
        private readonly IStartingTypeService _startingtypeService;
        public StartingTypeController(IUnitOfWork unitOfWork, ILogger<StartingTypeController> logger, IStartingTypeService startingtypeService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _startingtypeService = startingtypeService;
        }
        // GET: api/<StartingTypes>
        [HttpGet(nameof(GetStartingTypes))]
        [DisplayActionName(DisplayName = "استعلام أنواع البدء")]
        public IActionResult GetStartingTypes([FromQuery]SieveModel sieveModel) => Ok(_startingtypeService.GetAll(sieveModel));

        [HttpPost(nameof(CreateStartingType))]
        [DisplayActionName(DisplayName = "إنشاء نوع بدء جديد")]
        public async Task<IActionResult> CreateStartingType(StartingTypeDto startingtype)
        {
            if (ModelState.IsValid)
            {
                await _startingtypeService.Add(startingtype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=startingtype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateStartingType))]
        [DisplayActionName(DisplayName = "تعديل نوع البدء")]
        public async Task<IActionResult> UpdateStartingType(StartingTypeDto startingtype)
        {
            if (ModelState.IsValid)
            {
                await _startingtypeService.Update(startingtype);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = startingtype };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteStartingType))]
        [DisplayActionName(DisplayName = "حذف نوع البدء")]
        public async Task<IActionResult> DeleteStartingType(Guid id)
        {
            if (ModelState.IsValid)
            {
                _startingtypeService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
