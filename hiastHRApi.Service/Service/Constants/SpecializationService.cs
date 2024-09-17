using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class SpecializationService : ServiceAsync<Specialization,SpecializationDto>, ISpecializationService
    {
        private readonly IGenericRepository<Specialization>specializationRepository;
private readonly IMapper _mapper;
public SpecializationService (IGenericRepository<Specialization> repository, IMapper mapper) : base(repository, mapper){
            specializationRepository = repository;
            _mapper = mapper;
        }
    }
}