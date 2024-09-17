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
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CityController> _logger;
        private readonly ICityService _cityService;
        public CityController(IUnitOfWork unitOfWork, ILogger<CityController> logger, ICityService cityService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _cityService = cityService;
        }
        // GET: api/<Citys>
        [HttpGet(nameof(GetCitys))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetCitys([FromQuery]SieveModel sieveModel) => Ok(_cityService.GetAll(sieveModel));

        [HttpPost(nameof(CreateCity))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateCity(CityDto city)
        {
            if (ModelState.IsValid)
            {
                await _cityService.Add(city);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=city };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateCity))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateCity(CityDto city)
        {
            if (ModelState.IsValid)
            {
                await _cityService.Update(city);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = city };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteCity))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            if (ModelState.IsValid)
            {
                _cityService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
