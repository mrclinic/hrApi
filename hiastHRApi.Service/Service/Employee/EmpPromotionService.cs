using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpPromotionService : ServiceAsync<EmpPromotion,EmpPromotionDto>, IEmpPromotionService
    {
        private readonly IGenericRepository<EmpPromotion>emppromotionRepository;
private readonly IMapper _mapper;
public EmpPromotionService (IGenericRepository<EmpPromotion> repository, IMapper mapper) : base(repository, mapper){
            emppromotionRepository = repository;
            _mapper = mapper;
        }
    }
}