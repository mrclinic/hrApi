using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class InsuranceSystemService : ServiceAsync<InsuranceSystem,InsuranceSystemDto>, IInsuranceSystemService
    {
        private readonly IGenericRepository<InsuranceSystem>insurancesystemRepository;
private readonly IMapper _mapper;
public InsuranceSystemService (IGenericRepository<InsuranceSystem> repository, IMapper mapper) : base(repository, mapper){
            insurancesystemRepository = repository;
            _mapper = mapper;
        }
    }
}