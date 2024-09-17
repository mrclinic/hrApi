using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class FinancialIndicatorTypeService : ServiceAsync<FinancialIndicatorType,FinancialIndicatorTypeDto>, IFinancialIndicatorTypeService
    {
        private readonly IGenericRepository<FinancialIndicatorType>financialindicatortypeRepository;
private readonly IMapper _mapper;
public FinancialIndicatorTypeService (IGenericRepository<FinancialIndicatorType> repository, IMapper mapper) : base(repository, mapper){
            financialindicatortypeRepository = repository;
            _mapper = mapper;
        }
    }
}