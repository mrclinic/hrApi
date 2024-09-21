using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class RewardTypeService : ServiceAsync<RewardType,RewardTypeDto>, IRewardTypeService
    {
        private readonly IGenericRepository<RewardType>rewardtypeRepository;
private readonly IMapper _mapper;
public RewardTypeService (IGenericRepository<RewardType> repository, IMapper mapper) : base(repository, mapper){
            rewardtypeRepository = repository;
            _mapper = mapper;
        }
    }
}