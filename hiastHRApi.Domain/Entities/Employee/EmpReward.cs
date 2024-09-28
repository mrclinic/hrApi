
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpReward : AuditEntity
    {

        public DateTime OrderDate { get; set; }

        public DateTime ExecutionDate { get; set; }

        public DateTime ContractDate { get; set; }

        public Guid RewardTypeId { get; set; }

        public Guid OrgDepartmentId { get; set; }

        public Guid ContractTypeId { get; set; }

        public int DurationInDays { get; set; }

        public int PercentageOrAmount { get; set; }

        public Guid FinancialIndicatorTypeId { get; set; }

        public string Reason { get; set; } = null!;

        public string OrderNumber { get; set; } = null!;

        public string ContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual ModificationContractType ContractType { get; set; } = null!;

        public virtual OrgDepartment Department { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual FinancialIndicatorType FinancialIndicatorType { get; set; } = null!;

        public virtual RewardType RewardType { get; set; } = null!;
    }
}