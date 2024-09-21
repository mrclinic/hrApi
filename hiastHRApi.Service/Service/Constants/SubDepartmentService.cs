using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class SubDepartmentService : ServiceAsync<SubDepartment,SubDepartmentDto>, ISubDepartmentService
    {
        private readonly IGenericRepository<SubDepartment>subdepartmentRepository;
private readonly IMapper _mapper;
public SubDepartmentService (IGenericRepository<SubDepartment> repository, IMapper mapper) : base(repository, mapper){
            subdepartmentRepository = repository;
            _mapper = mapper;
        }
    }
}