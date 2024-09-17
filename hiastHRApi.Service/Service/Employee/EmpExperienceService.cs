using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpExperienceService : ServiceAsync<EmpExperience,EmpExperienceDto>, IEmpExperienceService
    {
        private readonly IGenericRepository<EmpExperience>empexperienceRepository;
private readonly IMapper _mapper;
public EmpExperienceService (IGenericRepository<EmpExperience> repository, IMapper mapper) : base(repository, mapper){
            empexperienceRepository = repository;
            _mapper = mapper;
        }
    }
}