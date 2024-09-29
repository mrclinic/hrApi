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
        [DisplayActionName(DisplayName ="استعلام الموظفين")]
        public IActionResult GetPersons([FromQuery]SieveModel sieveModel) => Ok(_personService.GetAll(sieveModel));
        [HttpGet(nameof(GetPersonsInfo))]
        [DisplayActionName(DisplayName = "استعلام الموظفين وتفاصيلهم")]
        public IActionResult GetPersonsInfo([FromQuery] SieveModel sieveModel) => Ok(_personService.Get(sieveModel, includeProperties: "BloodGroup,City,EmploymentStatusType,Gender,MaritalStatus,Nationality"));

        [HttpPost(nameof(CreatePerson))]
        [DisplayActionName(DisplayName = "إنشاء موظف جديد")]
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
        [DisplayActionName(DisplayName = "تعديل موظف")]
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
        [DisplayActionName(DisplayName = "حذف موظف")]
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
