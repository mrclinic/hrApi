
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpAssignment : AuditEntity
    {

        public DateTime ContractDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid ContractTypeId { get; set; }

        public string AssignedWork { get; set; } = null!;

        public string ContractNumber { get; set; } = null!;



        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual ModificationContractType ContractType { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;
    }
}