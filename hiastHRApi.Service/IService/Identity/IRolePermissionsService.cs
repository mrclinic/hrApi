
using hiastHRApi.Domain.Entities.Identity;
using hiastHRApi.Services.DTO.Identity;
using hiastHRApi.Services.IService;

namespace hiastHRApi.Service.IService.Identity
{
    public interface IRolePermissionsService : IServiceAsync<RolePermissions, RolePermissionsDto>
    {
    }
}
