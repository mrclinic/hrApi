using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class MilitarySpecializationService : ServiceAsync<MilitarySpecialization,MilitarySpecializationDto>, IMilitarySpecializationService
    {
        private readonly IGenericRepository<MilitarySpecialization>militaryspecializationRepository;
private readonly IMapper _mapper;
public MilitarySpecializationService (IGenericRepository<MilitarySpecialization> repository, IMapper mapper) : base(repository, mapper){
            militaryspecializationRepository = repository;
            _mapper = mapper;
        }
    }
}