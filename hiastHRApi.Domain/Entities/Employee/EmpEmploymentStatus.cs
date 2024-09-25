
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpEmploymentStatus : AuditEntity
    {

        public DateOnly StartDate { get; set; }

        public DateOnly ContractDate { get; set; }

        public Guid StartingTypeId { get; set; }

        public Guid ContractTypeId { get; set; }

        public string ContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual ModificationContractType ContractType { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual StartingType StartingType { get; set; } = null!;
    }
}