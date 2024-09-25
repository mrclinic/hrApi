


using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Employee
{
    public partial class EmpMilitaryServiceCohort : AuditEntity
    {

        public DateOnly StartDate { get; set; }

        public DateOnly StartContractDate { get; set; }

        public DateOnly EndDate { get; set; }

        public DateOnly EndContractDate { get; set; }

        public string StartContractNumber { get; set; } = null!;

        public string EndContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;
    }
}