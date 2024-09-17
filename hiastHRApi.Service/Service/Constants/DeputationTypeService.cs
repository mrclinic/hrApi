using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class DeputationTypeService : ServiceAsync<DeputationType,DeputationTypeDto>, IDeputationTypeService
    {
        private readonly IGenericRepository<DeputationType>deputationtypeRepository;
private readonly IMapper _mapper;
public DeputationTypeService (IGenericRepository<DeputationType> repository, IMapper mapper) : base(repository, mapper){
            deputationtypeRepository = repository;
            _mapper = mapper;
        }
    }
}