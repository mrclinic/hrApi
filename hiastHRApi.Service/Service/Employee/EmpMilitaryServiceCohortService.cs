using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpMilitaryServiceCohortService : ServiceAsync<EmpMilitaryServiceCohort,EmpMilitaryServiceCohortDto>, IEmpMilitaryServiceCohortService
    {
        private readonly IGenericRepository<EmpMilitaryServiceCohort>empmilitaryservicecohortRepository;
private readonly IMapper _mapper;
public EmpMilitaryServiceCohortService (IGenericRepository<EmpMilitaryServiceCohort> repository, IMapper mapper) : base(repository, mapper){
            empmilitaryservicecohortRepository = repository;
            _mapper = mapper;
        }
    }
}