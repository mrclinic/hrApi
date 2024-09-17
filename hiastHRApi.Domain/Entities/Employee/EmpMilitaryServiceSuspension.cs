using hiastHRApi.Domain.Entities.Base;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpMilitaryServiceSuspension : AuditEntity
    {

        public DateOnly SuspensionDate { get; set; }

        public DateOnly SuspensionContractDate { get; set; }

        public DateOnly ReturnToServiceDate { get; set; }

        public DateOnly ReturnContractDate { get; set; }

        public string SuspensionContractNumber { get; set; } = null!;

        public string ReturnContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;
    }
}