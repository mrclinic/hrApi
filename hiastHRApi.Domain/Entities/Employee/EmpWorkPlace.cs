using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Constants;


namespace hiastHRApi.Domain.Entities.Employee
{
    public partial class EmpWorkPlace : AuditEntity
    {

        public DateOnly DateOfStart { get; set; }

        public DateOnly DateOfRelinquishment { get; set; }

        public DateOnly DateOfContract { get; set; }

        public Guid ContractTypeId { get; set; }

        public string ContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual ModificationContractType ContractType { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;
    }
}