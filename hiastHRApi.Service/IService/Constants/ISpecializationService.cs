using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Services.IService;namespace hiastHRApi.Service.IService.Constants
{
    public interface ISpecializationService : IServiceAsync<Specialization,SpecializationDto>
    {
    }
}
