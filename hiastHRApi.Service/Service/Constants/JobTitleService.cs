using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class JobTitleService : ServiceAsync<JobTitle,JobTitleDto>, IJobTitleService
    {
        private readonly IGenericRepository<JobTitle>jobtitleRepository;
private readonly IMapper _mapper;
public JobTitleService (IGenericRepository<JobTitle> repository, IMapper mapper) : base(repository, mapper){
            jobtitleRepository = repository;
            _mapper = mapper;
        }
    }
}