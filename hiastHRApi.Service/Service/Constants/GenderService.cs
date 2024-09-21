using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class GenderService : ServiceAsync<Gender,GenderDto>, IGenderService
    {
        private readonly IGenericRepository<Gender>genderRepository;
private readonly IMapper _mapper;
public GenderService (IGenericRepository<Gender> repository, IMapper mapper) : base(repository, mapper){
            genderRepository = repository;
            _mapper = mapper;
        }
    }
}