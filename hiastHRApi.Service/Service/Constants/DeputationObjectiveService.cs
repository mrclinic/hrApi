using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class DeputationObjectiveService : ServiceAsync<DeputationObjective,DeputationObjectiveDto>, IDeputationObjectiveService
    {
        private readonly IGenericRepository<DeputationObjective>deputationobjectiveRepository;
private readonly IMapper _mapper;
public DeputationObjectiveService (IGenericRepository<DeputationObjective> repository, IMapper mapper) : base(repository, mapper){
            deputationobjectiveRepository = repository;
            _mapper = mapper;
        }
    }
}