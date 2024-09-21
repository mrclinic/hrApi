using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpMilitaryServiceSuspensionService : ServiceAsync<EmpMilitaryServiceSuspension,EmpMilitaryServiceSuspensionDto>, IEmpMilitaryServiceSuspensionService
    {
        private readonly IGenericRepository<EmpMilitaryServiceSuspension>empmilitaryservicesuspensionRepository;
private readonly IMapper _mapper;
public EmpMilitaryServiceSuspensionService (IGenericRepository<EmpMilitaryServiceSuspension> repository, IMapper mapper) : base(repository, mapper){
            empmilitaryservicesuspensionRepository = repository;
            _mapper = mapper;
        }
    }
}