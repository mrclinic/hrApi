using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class JobCategoryService : ServiceAsync<JobCategory,JobCategoryDto>, IJobCategoryService
    {
        private readonly IGenericRepository<JobCategory>jobcategoryRepository;
private readonly IMapper _mapper;
public JobCategoryService (IGenericRepository<JobCategory> repository, IMapper mapper) : base(repository, mapper){
            jobcategoryRepository = repository;
            _mapper = mapper;
        }
    }
}