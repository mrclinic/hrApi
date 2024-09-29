
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpPunishment : AuditEntity
    {

        public DateTime ExecutionDate { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ContractDate { get; set; }

        public Guid IssuingOrgDepartmentId { get; set; }

        public int DurationInDays { get; set; }

        public Guid OrderOrgDepartmentId { get; set; }

        public bool IsAppearingInRecordCard { get; set; }

        public Guid ContractTypeId { get; set; }

        public Guid PunishmentTypeId { get; set; }

        public int PercentageOrAmount { get; set; }

        public bool IsPercentage { get; set; }

        public string Reason { get; set; } = null!;

        public string OrderContractNumber { get; set; } = null!;

        public string ContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual ModificationContractType ContractType { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual OrgDepartment IssuingOrgDepartment { get; set; } = null!;

        public virtual OrgDepartment OrderOrgDepartment { get; set; } = null!;

        public virtual PunishmentType PunishmentType { get; set; } = null!;
    }
}