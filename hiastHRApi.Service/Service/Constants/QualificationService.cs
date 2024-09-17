using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class QualificationService : ServiceAsync<Qualification,QualificationDto>, IQualificationService
    {
        private readonly IGenericRepository<Qualification>qualificationRepository;
private readonly IMapper _mapper;
public QualificationService (IGenericRepository<Qualification> repository, IMapper mapper) : base(repository, mapper){
            qualificationRepository = repository;
            _mapper = mapper;
        }
    }
}