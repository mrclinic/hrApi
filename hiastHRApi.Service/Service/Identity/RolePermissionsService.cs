using AutoMapper;

using hiastHRApi.Domain.Entities.Identity;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Service.IService.Identity;
using hiastHRApi.Services.DTO.Identity;

namespace hiastHRApi.Service.Service.Identity
{
    public class RolePermissionsService : ServiceAsync<RolePermissions, RolePermissionsDto>, IRolePermissionsService
    {
        private readonly IGenericRepository<RolePermissions> rolePermissionsRepository;
        private readonly IMapper _mapper;

        public RolePermissionsService(IGenericRepository<RolePermissions> repository, IMapper mapper) : base(repository, mapper)
        {
            rolePermissionsRepository = repository;
            _mapper = mapper;
        }
    }
}
