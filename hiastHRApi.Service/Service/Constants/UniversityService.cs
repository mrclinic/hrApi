using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class UniversityService : ServiceAsync<University,UniversityDto>, IUniversityService
    {
        private readonly IGenericRepository<University>universityRepository;
private readonly IMapper _mapper;
public UniversityService (IGenericRepository<University> repository, IMapper mapper) : base(repository, mapper){
            universityRepository = repository;
            _mapper = mapper;
        }
    }
}