using AutoMapper; 
using hiastHRApi.Domain.Entities.Employee; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Employee; 
using hiastHRApi.Service.IService.Employee; 

namespace hiastHRApi.Service.Service.Employee
 {
    public class EmpPartnerService : ServiceAsync<EmpPartner,EmpPartnerDto>, IEmpPartnerService
    {
        private readonly IGenericRepository<EmpPartner>emppartnerRepository;
private readonly IMapper _mapper;
public EmpPartnerService (IGenericRepository<EmpPartner> repository, IMapper mapper) : base(repository, mapper){
            emppartnerRepository = repository;
            _mapper = mapper;
        }
    }
}