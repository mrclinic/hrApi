using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class StartingTypeService : ServiceAsync<StartingType,StartingTypeDto>, IStartingTypeService
    {
        private readonly IGenericRepository<StartingType>startingtypeRepository;
private readonly IMapper _mapper;
public StartingTypeService (IGenericRepository<StartingType> repository, IMapper mapper) : base(repository, mapper){
            startingtypeRepository = repository;
            _mapper = mapper;
        }
    }
}