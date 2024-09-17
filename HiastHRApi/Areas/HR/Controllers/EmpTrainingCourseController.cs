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
    public class EmpTrainingCourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmpTrainingCourseController> _logger;
        private readonly IEmpTrainingCourseService _emptrainingcourseService;
        public EmpTrainingCourseController(IUnitOfWork unitOfWork, ILogger<EmpTrainingCourseController> logger, IEmpTrainingCourseService emptrainingcourseService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emptrainingcourseService = emptrainingcourseService;
        }
        // GET: api/<EmpTrainingCourses>
        [HttpGet(nameof(GetEmpTrainingCourses))]
        [DisplayActionName(DisplayName ="استعلام فروع النقابة")]
        public IActionResult GetEmpTrainingCourses([FromQuery]SieveModel sieveModel) => Ok(_emptrainingcourseService.GetAll(sieveModel));

        [HttpPost(nameof(CreateEmpTrainingCourse))]
        [DisplayActionName(DisplayName = "إنشاء فرع جديد")]
        public async Task<IActionResult> CreateEmpTrainingCourse(EmpTrainingCourseDto emptrainingcourse)
        {
            if (ModelState.IsValid)
            {
                await _emptrainingcourseService.Add(emptrainingcourse);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200 ,Value=emptrainingcourse };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut(nameof(UpdateEmpTrainingCourse))]
        [DisplayActionName(DisplayName = "تعديل فرع")]
        public async Task<IActionResult> UpdateEmpTrainingCourse(EmpTrainingCourseDto emptrainingcourse)
        {
            if (ModelState.IsValid)
            {
                await _emptrainingcourseService.Update(emptrainingcourse);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = emptrainingcourse };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpDelete(nameof(DeleteEmpTrainingCourse))]
        [DisplayActionName(DisplayName = "حذف فرع")]
        public async Task<IActionResult> DeleteEmpTrainingCourse(Guid id)
        {
            if (ModelState.IsValid)
            {
                _emptrainingcourseService.Delete(id);
                await _unitOfWork.CompleteAsync();
                return new JsonResult("Success") { StatusCode = 200, Value = true };
            }
            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
    }
}
