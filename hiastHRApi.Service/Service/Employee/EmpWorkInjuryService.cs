using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpWorkInjuryService : ServiceAsync<EmpWorkInjury,EmpWorkInjuryDto>, IEmpWorkInjuryService
    {
        private readonly IGenericRepository<EmpWorkInjury>empworkinjuryRepository;
private readonly IMapper _mapper;
public EmpWorkInjuryService (IGenericRepository<EmpWorkInjury> repository, IMapper mapper) : base(repository, mapper){
            empworkinjuryRepository = repository;
            _mapper = mapper;
        }
    }
}