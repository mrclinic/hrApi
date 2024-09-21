using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class PersonService : ServiceAsync<EmpPersonalInfo, PersonDto>, IPersonService
    {
        private readonly IGenericRepository<EmpPersonalInfo> personRepository;
private readonly IMapper _mapper;
public PersonService (IGenericRepository<EmpPersonalInfo> repository, IMapper mapper) : base(repository, mapper){
            personRepository = repository;
            _mapper = mapper;
        }
    }
}