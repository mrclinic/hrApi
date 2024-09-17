using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class OccurrencePartnerTypeService : ServiceAsync<OccurrencePartnerType,OccurrencePartnerTypeDto>, IOccurrencePartnerTypeService
    {
        private readonly IGenericRepository<OccurrencePartnerType>occurrencepartnertypeRepository;
private readonly IMapper _mapper;
public OccurrencePartnerTypeService (IGenericRepository<OccurrencePartnerType> repository, IMapper mapper) : base(repository, mapper){
            occurrencepartnertypeRepository = repository;
            _mapper = mapper;
        }
    }
}