using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class PunishmentTypeService : ServiceAsync<PunishmentType,PunishmentTypeDto>, IPunishmentTypeService
    {
        private readonly IGenericRepository<PunishmentType>punishmenttypeRepository;
private readonly IMapper _mapper;
public PunishmentTypeService (IGenericRepository<PunishmentType> repository, IMapper mapper) : base(repository, mapper){
            punishmenttypeRepository = repository;
            _mapper = mapper;
        }
    }
}