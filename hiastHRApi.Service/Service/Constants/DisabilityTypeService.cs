using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class DisabilityTypeService : ServiceAsync<DisabilityType,DisabilityTypeDto>, IDisabilityTypeService
    {
        private readonly IGenericRepository<DisabilityType>disabilitytypeRepository;
private readonly IMapper _mapper;
public DisabilityTypeService (IGenericRepository<DisabilityType> repository, IMapper mapper) : base(repository, mapper){
            disabilitytypeRepository = repository;
            _mapper = mapper;
        }
    }
}