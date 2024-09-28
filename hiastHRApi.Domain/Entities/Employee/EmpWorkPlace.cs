
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;


namespace hiastHRApi.Domain.Entities.Employee
{
    public partial class EmpWorkPlace : AuditEntity
    {

        public DateTime DateOfStart { get; set; }

        public DateTime DateOfRelinquishment { get; set; }

        public DateTime DateOfContract { get; set; }

        public Guid ContractTypeId { get; set; }

        public string ContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual ModificationContractType ContractType { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;
    }
}