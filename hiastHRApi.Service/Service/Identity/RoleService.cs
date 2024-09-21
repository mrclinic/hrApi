using AutoMapper;

using hiastHRApi.Domain.Entities.Identity;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Service.IService.Identity;
using hiastHRApi.Services.DTO.Identity;

namespace hiastHRApi.Service.Service.Identity
{
    public class RoleService : ServiceAsync<Role, RoleDto>, IRoleService
    {
        private readonly IGenericRepository<Role> roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IGenericRepository<Role> repository, IMapper mapper) : base(repository, mapper)
        {
            roleRepository = repository;
            _mapper = mapper;
        }
    }
}
