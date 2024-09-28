


using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;

namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpWorkInjury : AuditEntity
    {

        public DateTime ContractDate { get; set; }

        public decimal DisabilityRatio { get; set; }

        public decimal LumpSumAmount { get; set; }

        public decimal MonthlyAmount { get; set; }

        public string InjuryType { get; set; } = null!;

        public string ContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;
    }
}