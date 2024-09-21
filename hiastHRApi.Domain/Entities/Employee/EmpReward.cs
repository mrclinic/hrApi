using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Constants;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpReward : AuditEntity
    {

        public DateOnly OrderDate { get; set; }

        public DateOnly ExecutionDate { get; set; }

        public DateOnly ContractDate { get; set; }

        public Guid RewardTypeId { get; set; }

        public Guid DepartmentId { get; set; }

        public Guid ContractTypeId { get; set; }

        public int DurationInDays { get; set; }

        public int PercentageOrAmount { get; set; }

        public Guid FinancialIndicatorTypeId { get; set; }

        public string Reason { get; set; } = null!;

        public string OrderNumber { get; set; } = null!;

        public string ContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual ModificationContractType ContractType { get; set; } = null!;

        public virtual Department Department { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual FinancialIndicatorType FinancialIndicatorType { get; set; } = null!;

        public virtual RewardType RewardType { get; set; } = null!;
    }
}