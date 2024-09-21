using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class HealthyStatusService : ServiceAsync<HealthyStatus,HealthyStatusDto>, IHealthyStatusService
    {
        private readonly IGenericRepository<HealthyStatus>healthystatusRepository;
private readonly IMapper _mapper;
public HealthyStatusService (IGenericRepository<HealthyStatus> repository, IMapper mapper) : base(repository, mapper){
            healthystatusRepository = repository;
            _mapper = mapper;
        }
    }
}