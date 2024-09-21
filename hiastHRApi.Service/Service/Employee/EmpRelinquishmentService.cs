using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpRelinquishmentService : ServiceAsync<EmpRelinquishment,EmpRelinquishmentDto>, IEmpRelinquishmentService
    {
        private readonly IGenericRepository<EmpRelinquishment>emprelinquishmentRepository;
private readonly IMapper _mapper;
public EmpRelinquishmentService (IGenericRepository<EmpRelinquishment> repository, IMapper mapper) : base(repository, mapper){
            emprelinquishmentRepository = repository;
            _mapper = mapper;
        }
    }
}