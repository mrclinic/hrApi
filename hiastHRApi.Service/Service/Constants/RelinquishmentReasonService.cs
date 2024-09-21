using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class RelinquishmentReasonService : ServiceAsync<RelinquishmentReason,RelinquishmentReasonDto>, IRelinquishmentReasonService
    {
        private readonly IGenericRepository<RelinquishmentReason>relinquishmentreasonRepository;
private readonly IMapper _mapper;
public RelinquishmentReasonService (IGenericRepository<RelinquishmentReason> repository, IMapper mapper) : base(repository, mapper){
            relinquishmentreasonRepository = repository;
            _mapper = mapper;
        }
    }
}