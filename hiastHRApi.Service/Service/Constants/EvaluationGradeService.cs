using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class EvaluationGradeService : ServiceAsync<EvaluationGrade,EvaluationGradeDto>, IEvaluationGradeService
    {
        private readonly IGenericRepository<EvaluationGrade>evaluationgradeRepository;
private readonly IMapper _mapper;
public EvaluationGradeService (IGenericRepository<EvaluationGrade> repository, IMapper mapper) : base(repository, mapper){
            evaluationgradeRepository = repository;
            _mapper = mapper;
        }
    }
}