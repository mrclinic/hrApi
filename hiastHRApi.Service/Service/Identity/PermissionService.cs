using AutoMapper;

using hiastHRApi.Domain.Entities.Identity;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Service.IService.Identity;
using hiastHRApi.Services.DTO.Identity;

namespace hiastHRApi.Service.Service.Identity
{
    public class PermissionService : ServiceAsync<Permission, PermissionDto>, IPermissionService
    {
        private readonly IGenericRepository<Permission> permissionRepository;
        private readonly IMapper _mapper;

        public PermissionService(IGenericRepository<Permission> repository, IMapper mapper) : base(repository, mapper)
        {
            permissionRepository = repository;
            _mapper = mapper;
        }

        public async Task<PermissionDto> FindPermissionByName(string permissionName)
        {
            var permission = await permissionRepository.FindSingle(x => x.NAME.Equals(permissionName));
            return _mapper.Map<PermissionDto>(permission);
        }
    }
}
