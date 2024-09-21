using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpDeputationService : ServiceAsync<EmpDeputation,EmpDeputationDto>, IEmpDeputationService
    {
        private readonly IGenericRepository<EmpDeputation>empdeputationRepository;
private readonly IMapper _mapper;
public EmpDeputationService (IGenericRepository<EmpDeputation> repository, IMapper mapper) : base(repository, mapper){
            empdeputationRepository = repository;
            _mapper = mapper;
        }
    }
}