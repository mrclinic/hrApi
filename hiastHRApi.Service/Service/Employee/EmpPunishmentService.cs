using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpPunishmentService : ServiceAsync<EmpPunishment,EmpPunishmentDto>, IEmpPunishmentService
    {
        private readonly IGenericRepository<EmpPunishment>emppunishmentRepository;
private readonly IMapper _mapper;
public EmpPunishmentService (IGenericRepository<EmpPunishment> repository, IMapper mapper) : base(repository, mapper){
            emppunishmentRepository = repository;
            _mapper = mapper;
        }
    }
}