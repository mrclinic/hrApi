using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class MilitaryRankService : ServiceAsync<MilitaryRank,MilitaryRankDto>, IMilitaryRankService
    {
        private readonly IGenericRepository<MilitaryRank>militaryrankRepository;
private readonly IMapper _mapper;
public MilitaryRankService (IGenericRepository<MilitaryRank> repository, IMapper mapper) : base(repository, mapper){
            militaryrankRepository = repository;
            _mapper = mapper;
        }
    }
}