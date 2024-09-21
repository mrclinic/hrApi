using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpEmploymentStatusService : ServiceAsync<EmpEmploymentStatus,EmpEmploymentStatusDto>, IEmpEmploymentStatusService
    {
        private readonly IGenericRepository<EmpEmploymentStatus>empemploymentstatusRepository;
private readonly IMapper _mapper;
public EmpEmploymentStatusService (IGenericRepository<EmpEmploymentStatus> repository, IMapper mapper) : base(repository, mapper){
            empemploymentstatusRepository = repository;
            _mapper = mapper;
        }
    }
}