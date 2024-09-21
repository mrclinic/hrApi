using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class EmploymentStatusTypeService : ServiceAsync<EmploymentStatusType,EmploymentStatusTypeDto>, IEmploymentStatusTypeService
    {
        private readonly IGenericRepository<EmploymentStatusType>employmentstatustypeRepository;
private readonly IMapper _mapper;
public EmploymentStatusTypeService (IGenericRepository<EmploymentStatusType> repository, IMapper mapper) : base(repository, mapper){
            employmentstatustypeRepository = repository;
            _mapper = mapper;
        }
    }
}