using AutoMapper;
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Service.DTO.Employee;
using hiastHRApi.Service.IService.Employee;

namespace hiastHRApi.Service.Service.Employee
{
    public class EmpAppointmentStatusService : ServiceAsync<EmpAppointmentStatus, EmpAppointmentStatusDto>, IEmpAppointmentStatusService
    {
        private readonly IGenericRepository<EmpAppointmentStatus> empappointmentstatusRepository;
        private readonly IMapper _mapper;
        public EmpAppointmentStatusService(IGenericRepository<EmpAppointmentStatus> repository, IMapper mapper) : base(repository, mapper)
        {
            empappointmentstatusRepository = repository;
            _mapper = mapper;
        }
    }
}