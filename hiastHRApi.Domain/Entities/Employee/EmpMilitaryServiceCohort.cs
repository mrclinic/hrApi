


using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;

namespace hiastHRApi.Domain.Entities.Employee
{
    public partial class EmpMilitaryServiceCohort : AuditEntity
    {

        public DateTime StartDate { get; set; }

        public DateTime StartContractDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime EndContractDate { get; set; }

        public string StartContractNumber { get; set; } = null!;

        public string EndContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;
    }
}