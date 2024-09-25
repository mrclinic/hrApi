


using hiastHRApi.Shared.Base;

namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpWorkInjury : AuditEntity
    {

        public DateOnly ContractDate { get; set; }

        public decimal DisabilityRatio { get; set; }

        public decimal LumpSumAmount { get; set; }

        public decimal MonthlyAmount { get; set; }

        public string InjuryType { get; set; } = null!;

        public string ContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;
    }
}