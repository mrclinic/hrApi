using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class ModificationContractTypeService : ServiceAsync<ModificationContractType,ModificationContractTypeDto>, IModificationContractTypeService
    {
        private readonly IGenericRepository<ModificationContractType>modificationcontracttypeRepository;
private readonly IMapper _mapper;
public ModificationContractTypeService (IGenericRepository<ModificationContractType> repository, IMapper mapper) : base(repository, mapper){
            modificationcontracttypeRepository = repository;
            _mapper = mapper;
        }
    }
}