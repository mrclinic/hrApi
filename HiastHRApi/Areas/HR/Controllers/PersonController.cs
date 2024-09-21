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
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;
        public PersonController(IUnitOfWork unitOfWork, ILogger<PersonController> logger, IPersonService personService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _personService = personService;
        }
        // GET: api/<Persons>
        [HttpGet(nameof(GetPersons))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetPersons([FromQuery]SieveModel sieveModel) => Ok(_personService.GetAll(sieveModel));

        [HttpPost(nameof(CreatePerson))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreatePerson(PersonDto person)
        {
            if (ModelState.IsValid)
            {
                await _personService.Add(person);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=person };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdatePerson))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdatePerson(PersonDto person)
        {
            if (ModelState.IsValid)
            {
                await _personService.Update(person);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = person };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeletePerson))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            if (ModelState.IsValid)
            {
                _personService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
