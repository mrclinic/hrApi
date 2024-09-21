using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class LawService : ServiceAsync<Law,LawDto>, ILawService
    {
        private readonly IGenericRepository<Law>lawRepository;
private readonly IMapper _mapper;
public LawService (IGenericRepository<Law> repository, IMapper mapper) : base(repository, mapper){
            lawRepository = repository;
            _mapper = mapper;
        }
    }
}