using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class JobChangeReasonService : ServiceAsync<JobChangeReason,JobChangeReasonDto>, IJobChangeReasonService
    {
        private readonly IGenericRepository<JobChangeReason>jobchangereasonRepository;
private readonly IMapper _mapper;
public JobChangeReasonService (IGenericRepository<JobChangeReason> repository, IMapper mapper) : base(repository, mapper){
            jobchangereasonRepository = repository;
            _mapper = mapper;
        }
    }
}