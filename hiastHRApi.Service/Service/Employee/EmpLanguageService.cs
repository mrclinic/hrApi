using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpLanguageService : ServiceAsync<EmpLanguage,EmpLanguageDto>, IEmpLanguageService
    {
        private readonly IGenericRepository<EmpLanguage>emplanguageRepository;
private readonly IMapper _mapper;
public EmpLanguageService (IGenericRepository<EmpLanguage> repository, IMapper mapper) : base(repository, mapper){
            emplanguageRepository = repository;
            _mapper = mapper;
        }
    }
}