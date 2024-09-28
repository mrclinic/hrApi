using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{
    public partial class OrgDepartment : AuditEntity
    {
        public string Name { get; set; } = null!;
        public Guid? ParentId { get; set; }
        public OrgDepartment? Parent { get; set; }
        public ICollection<OrgDepartment> SubOrgDepartments { get; } = new List<OrgDepartment>();
        public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();
        public virtual ICollection<EmpPunishment> EmpPunishmentIssuingDepartments { get; set; } = new List<EmpPunishment>();
        public virtual ICollection<EmpPunishment> EmpPunishmentOrderDepartments { get; set; } = new List<EmpPunishment>();
        public virtual ICollection<EmpReward> EmpRewards { get; set; } = new List<EmpReward>();
    }
}
