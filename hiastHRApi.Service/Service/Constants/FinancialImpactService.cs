using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class FinancialImpactService : ServiceAsync<FinancialImpact,FinancialImpactDto>, IFinancialImpactService
    {
        private readonly IGenericRepository<FinancialImpact>financialimpactRepository;
private readonly IMapper _mapper;
public FinancialImpactService (IGenericRepository<FinancialImpact> repository, IMapper mapper) : base(repository, mapper){
            financialimpactRepository = repository;
            _mapper = mapper;
        }
    }
}