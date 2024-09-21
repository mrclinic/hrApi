using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpAssignmentService : ServiceAsync<EmpAssignment,EmpAssignmentDto>, IEmpAssignmentService
    {
        private readonly IGenericRepository<EmpAssignment>empassignmentRepository;
private readonly IMapper _mapper;
public EmpAssignmentService (IGenericRepository<EmpAssignment> repository, IMapper mapper) : base(repository, mapper){
            empassignmentRepository = repository;
            _mapper = mapper;
        }
    }
}