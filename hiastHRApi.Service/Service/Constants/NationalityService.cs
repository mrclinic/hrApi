using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class NationalityService : ServiceAsync<Nationality,NationalityDto>, INationalityService
    {
        private readonly IGenericRepository<Nationality>nationalityRepository;
private readonly IMapper _mapper;
public NationalityService (IGenericRepository<Nationality> repository, IMapper mapper) : base(repository, mapper){
            nationalityRepository = repository;
            _mapper = mapper;
        }
    }
}