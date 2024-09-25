
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class InsuranceSystem : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpAppointmentStatus> EmpAppointmentStatuses { get; set; } = new List<EmpAppointmentStatus>();
    }
}