using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class LanguageService : ServiceAsync<Language,LanguageDto>, ILanguageService
    {
        private readonly IGenericRepository<Language>languageRepository;
private readonly IMapper _mapper;
public LanguageService (IGenericRepository<Language> repository, IMapper mapper) : base(repository, mapper){
            languageRepository = repository;
            _mapper = mapper;
        }
    }
}