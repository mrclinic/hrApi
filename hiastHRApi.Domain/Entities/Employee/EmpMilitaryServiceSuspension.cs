


using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;

namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpMilitaryServiceSuspension : AuditEntity
    {

        public DateTime SuspensionDate { get; set; }

        public DateTime SuspensionContractDate { get; set; }

        public DateTime ReturnToServiceDate { get; set; }

        public DateTime ReturnContractDate { get; set; }

        public string SuspensionContractNumber { get; set; } = null!;

        public string ReturnContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;
    }
}