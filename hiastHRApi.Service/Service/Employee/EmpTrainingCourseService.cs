using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpTrainingCourseService : ServiceAsync<EmpTrainingCourse,EmpTrainingCourseDto>, IEmpTrainingCourseService
    {
        private readonly IGenericRepository<EmpTrainingCourse>emptrainingcourseRepository;
private readonly IMapper _mapper;
public EmpTrainingCourseService (IGenericRepository<EmpTrainingCourse> repository, IMapper mapper) : base(repository, mapper){
            emptrainingcourseRepository = repository;
            _mapper = mapper;
        }
    }
}