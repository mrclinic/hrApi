using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Constants;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpPunishment : AuditEntity
    {

        public DateOnly ExecutionDate { get; set; }

        public DateOnly OrderDate { get; set; }

        public DateOnly ContractDate { get; set; }

        public Guid IssuingDepartmentId { get; set; }

        public int DurationInDays { get; set; }

        public Guid OrderDepartmentId { get; set; }

        public bool IsAppearingInRecordCard { get; set; }

        public Guid ContractTypeId { get; set; }

        public Guid PunishmentTypeId { get; set; }

        public int PercentageOrAmount { get; set; }

        public bool IsPercentage { get; set; }

        public string Reason { get; set; } = null!;

        public string OrderContractNumber { get; set; } = null!;

        public string ContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual ModificationContractType ContractType { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual Department IssuingDepartment { get; set; } = null!;

        public virtual Department OrderDepartment { get; set; } = null!;

        public virtual PunishmentType PunishmentType { get; set; } = null!;
    }
}