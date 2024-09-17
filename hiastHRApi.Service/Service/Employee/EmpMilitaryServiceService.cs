using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpMilitaryServiceService : ServiceAsync<EmpMilitaryService,EmpMilitaryServiceDto>, IEmpMilitaryServiceService
    {
        private readonly IGenericRepository<EmpMilitaryService>empmilitaryserviceRepository;
private readonly IMapper _mapper;
public EmpMilitaryServiceService (IGenericRepository<EmpMilitaryService> repository, IMapper mapper) : base(repository, mapper){
            empmilitaryserviceRepository = repository;
            _mapper = mapper;
        }
    }
}