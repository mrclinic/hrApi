using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpQualificationService : ServiceAsync<EmpQualification,EmpQualificationDto>, IEmpQualificationService
    {
        private readonly IGenericRepository<EmpQualification>empqualificationRepository;
private readonly IMapper _mapper;
public EmpQualificationService (IGenericRepository<EmpQualification> repository, IMapper mapper) : base(repository, mapper){
            empqualificationRepository = repository;
            _mapper = mapper;
        }
    }
}