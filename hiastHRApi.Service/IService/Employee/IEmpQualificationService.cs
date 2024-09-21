using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Service.DTO.Employee;
using hiastHRApi.Services.IService;namespace hiastHRApi.Service.IService.Employee
{
    public interface IEmpQualificationService : IServiceAsync<EmpQualification,EmpQualificationDto>
    {
    }
}
