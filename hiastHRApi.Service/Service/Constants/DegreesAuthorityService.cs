using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class DegreesAuthorityService : ServiceAsync<DegreesAuthority,DegreesAuthorityDto>, IDegreesAuthorityService
    {
        private readonly IGenericRepository<DegreesAuthority>degreesauthorityRepository;
private readonly IMapper _mapper;
public DegreesAuthorityService (IGenericRepository<DegreesAuthority> repository, IMapper mapper) : base(repository, mapper){
            degreesauthorityRepository = repository;
            _mapper = mapper;
        }
    }
}