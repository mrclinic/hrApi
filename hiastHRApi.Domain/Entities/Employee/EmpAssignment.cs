using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Constants;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpAssignment : AuditEntity
    {

        public DateOnly ContractDate { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public Guid ContractTypeId { get; set; }

        public string AssignedWork { get; set; } = null!;

        public string ContractNumber { get; set; } = null!;



        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual ModificationContractType ContractType { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;
    }
}