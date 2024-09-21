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
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryService _countryService;
        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, ICountryService countryService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _countryService = countryService;
        }
        // GET: api/<Countrys>
        [HttpGet(nameof(GetCountrys))]
        [DisplayActionName(DisplayName = "استعلام البلدان")]
        public IActionResult GetCountrys([FromQuery] SieveModel sieveModel) => Ok(_countryService.GetAll(sieveModel));

        [HttpPost(nameof(CreateCountry))]
        [DisplayActionName(DisplayName = "إضافة بلد جديد")]
        public async Task<IActionResult> CreateCountry(CountryDto country)
        {
            if (ModelState.IsValid)
            {
                await _countryService.Add(country);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = country };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateCountry))]
        [DisplayActionName(DisplayName = "تعديل بلد")]
        public async Task<IActionResult> UpdateCountry(CountryDto country)
        {
            if (ModelState.IsValid)
            {
                await _countryService.Update(country);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = country };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteCountry))]
        [DisplayActionName(DisplayName = "حذف بلد")]
        public async Task<IActionResult> DeleteCountry(Guid id)
        {
            if (ModelState.IsValid)
            {
                _countryService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
