using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class TerminationReasonService : ServiceAsync<TerminationReason,TerminationReasonDto>, ITerminationReasonService
    {
        private readonly IGenericRepository<TerminationReason>terminationreasonRepository;
private readonly IMapper _mapper;
public TerminationReasonService (IGenericRepository<TerminationReason> repository, IMapper mapper) : base(repository, mapper){
            terminationreasonRepository = repository;
            _mapper = mapper;
        }
    }
}