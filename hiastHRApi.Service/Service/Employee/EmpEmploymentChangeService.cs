using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpEmploymentChangeService : ServiceAsync<EmpEmploymentChange,EmpEmploymentChangeDto>, IEmpEmploymentChangeService
    {
        private readonly IGenericRepository<EmpEmploymentChange>empemploymentchangeRepository;
private readonly IMapper _mapper;
public EmpEmploymentChangeService (IGenericRepository<EmpEmploymentChange> repository, IMapper mapper) : base(repository, mapper){
            empemploymentchangeRepository = repository;
            _mapper = mapper;
        }
    }
}