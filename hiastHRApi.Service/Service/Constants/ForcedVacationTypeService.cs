using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class ForcedVacationTypeService : ServiceAsync<ForcedVacationType,ForcedVacationTypeDto>, IForcedVacationTypeService
    {
        private readonly IGenericRepository<ForcedVacationType>forcedvacationtypeRepository;
private readonly IMapper _mapper;
public ForcedVacationTypeService (IGenericRepository<ForcedVacationType> repository, IMapper mapper) : base(repository, mapper){
            forcedvacationtypeRepository = repository;
            _mapper = mapper;
        }
    }
}