using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class DeputationStatusService : ServiceAsync<DeputationStatus,DeputationStatusDto>, IDeputationStatusService
    {
        private readonly IGenericRepository<DeputationStatus>deputationstatusRepository;
private readonly IMapper _mapper;
public DeputationStatusService (IGenericRepository<DeputationStatus> repository, IMapper mapper) : base(repository, mapper){
            deputationstatusRepository = repository;
            _mapper = mapper;
        }
    }
}