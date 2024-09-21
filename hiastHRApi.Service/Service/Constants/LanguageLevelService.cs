using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class LanguageLevelService : ServiceAsync<LanguageLevel,LanguageLevelDto>, ILanguageLevelService
    {
        private readonly IGenericRepository<LanguageLevel>languagelevelRepository;
private readonly IMapper _mapper;
public LanguageLevelService (IGenericRepository<LanguageLevel> repository, IMapper mapper) : base(repository, mapper){
            languagelevelRepository = repository;
            _mapper = mapper;
        }
    }
}