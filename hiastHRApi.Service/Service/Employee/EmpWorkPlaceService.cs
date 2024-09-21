using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpWorkPlaceService : ServiceAsync<EmpWorkPlace,EmpWorkPlaceDto>, IEmpWorkPlaceService
    {
        private readonly IGenericRepository<EmpWorkPlace>empworkplaceRepository;
private readonly IMapper _mapper;
public EmpWorkPlaceService (IGenericRepository<EmpWorkPlace> repository, IMapper mapper) : base(repository, mapper){
            empworkplaceRepository = repository;
            _mapper = mapper;
        }
    }
}