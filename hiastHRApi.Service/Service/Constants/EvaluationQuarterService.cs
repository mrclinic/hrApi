using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class EvaluationQuarterService : ServiceAsync<EvaluationQuarter,EvaluationQuarterDto>, IEvaluationQuarterService
    {
        private readonly IGenericRepository<EvaluationQuarter>evaluationquarterRepository;
private readonly IMapper _mapper;
public EvaluationQuarterService (IGenericRepository<EvaluationQuarter> repository, IMapper mapper) : base(repository, mapper){
            evaluationquarterRepository = repository;
            _mapper = mapper;
        }
    }
}