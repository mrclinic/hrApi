using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpRewardService : ServiceAsync<EmpReward,EmpRewardDto>, IEmpRewardService
    {
        private readonly IGenericRepository<EmpReward>emprewardRepository;
private readonly IMapper _mapper;
public EmpRewardService (IGenericRepository<EmpReward> repository, IMapper mapper) : base(repository, mapper){
            emprewardRepository = repository;
            _mapper = mapper;
        }
    }
}