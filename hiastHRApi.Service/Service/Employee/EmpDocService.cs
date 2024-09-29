using AutoMapper;
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Service.DTO.Employee;
using hiastHRApi.Service.IService.Employee;

namespace hiastHRApi.Service.Service.Employee
{
    public class EmpDocService : ServiceAsync<EmpDoc, EmpDocDto>, IEmpDocService
    {
        private readonly IGenericRepository<EmpDoc> empDocRepository;
        private readonly IMapper _mapper;
        public EmpDocService(IGenericRepository<EmpDoc> repository, IMapper mapper) : base(repository, mapper)
        {
            empDocRepository = repository;
            _mapper = mapper;
        }
    }
}