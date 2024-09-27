using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Service.IService.Constants;

namespace hiastHRApi.Service.Service.Constants
{
    public class OrgDepartmentService : ServiceAsync<OrgDepartment, OrgDepartmentDto>, IOrgDepartmentService
    {
        private readonly IGenericRepository<OrgDepartment> OrgDepartmentRepository;
        private readonly IMapper _mapper;
        public OrgDepartmentService(IGenericRepository<OrgDepartment> repository, IMapper mapper) : base(repository, mapper)
        {
            OrgDepartmentRepository = repository;
            _mapper = mapper;
        }
    }
}