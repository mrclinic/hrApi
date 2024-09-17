using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class ExperienceTypeService : ServiceAsync<ExperienceType,ExperienceTypeDto>, IExperienceTypeService
    {
        private readonly IGenericRepository<ExperienceType>experiencetypeRepository;
private readonly IMapper _mapper;
public ExperienceTypeService (IGenericRepository<ExperienceType> repository, IMapper mapper) : base(repository, mapper){
            experiencetypeRepository = repository;
            _mapper = mapper;
        }
    }
}