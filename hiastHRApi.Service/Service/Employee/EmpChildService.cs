using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpChildService : ServiceAsync<EmpChild,EmpChildDto>, IEmpChildService
    {
        private readonly IGenericRepository<EmpChild>empchildRepository;
private readonly IMapper _mapper;
public EmpChildService (IGenericRepository<EmpChild> repository, IMapper mapper) : base(repository, mapper){
            empchildRepository = repository;
            _mapper = mapper;
        }
    }
}