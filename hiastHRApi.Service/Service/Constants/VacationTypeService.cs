using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class VacationTypeService : ServiceAsync<VacationType,VacationTypeDto>, IVacationTypeService
    {
        private readonly IGenericRepository<VacationType>vacationtypeRepository;
private readonly IMapper _mapper;
public VacationTypeService (IGenericRepository<VacationType> repository, IMapper mapper) : base(repository, mapper){
            vacationtypeRepository = repository;
            _mapper = mapper;
        }
    }
}