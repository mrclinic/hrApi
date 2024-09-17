using AutoMapper;
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Service.DTO.Employee;
using hiastHRApi.Service.IService.Employee;

namespace hiastHRApi.Service.Service.Employee
{
    public class EmpPerformanceEvaluationService : ServiceAsync<EmpPerformanceEvaluation, EmpPerformanceEvaluationDto>, IEmpPerformanceEvaluationService
    {
        private readonly IGenericRepository<EmpPerformanceEvaluation> empperformanceevaluationRepository;
        private readonly IMapper _mapper;
        public EmpPerformanceEvaluationService(IGenericRepository<EmpPerformanceEvaluation> repository, IMapper mapper) : base(repository, mapper)
        {
            empperformanceevaluationRepository = repository;
            _mapper = mapper;
        }
    }
}