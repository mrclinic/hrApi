using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class MaritalStatusService : ServiceAsync<MaritalStatus,MaritalStatusDto>, IMaritalStatusService
    {
        private readonly IGenericRepository<MaritalStatus>maritalstatusRepository;
private readonly IMapper _mapper;
public MaritalStatusService (IGenericRepository<MaritalStatus> repository, IMapper mapper) : base(repository, mapper){
            maritalstatusRepository = repository;
            _mapper = mapper;
        }
    }
}