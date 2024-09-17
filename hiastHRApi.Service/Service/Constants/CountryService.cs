using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class CountryService : ServiceAsync<Country,CountryDto>, ICountryService
    {
        private readonly IGenericRepository<Country>countryRepository;
private readonly IMapper _mapper;
public CountryService (IGenericRepository<Country> repository, IMapper mapper) : base(repository, mapper){
            countryRepository = repository;
            _mapper = mapper;
        }
    }
}