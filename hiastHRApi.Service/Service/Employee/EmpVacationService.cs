using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpVacationService : ServiceAsync<EmpVacation,EmpVacationDto>, IEmpVacationService
    {
        private readonly IGenericRepository<EmpVacation>empvacationRepository;
private readonly IMapper _mapper;
public EmpVacationService (IGenericRepository<EmpVacation> repository, IMapper mapper) : base(repository, mapper){
            empvacationRepository = repository;
            _mapper = mapper;
        }
    }
}