using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class DepartmentService : ServiceAsync<Department,DepartmentDto>, IDepartmentService
    {
        private readonly IGenericRepository<Department>departmentRepository;
private readonly IMapper _mapper;
public DepartmentService (IGenericRepository<Department> repository, IMapper mapper) : base(repository, mapper){
            departmentRepository = repository;
            _mapper = mapper;
        }
    }
}