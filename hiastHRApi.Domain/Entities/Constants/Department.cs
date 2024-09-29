
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class Department : AuditEntity
    {
        public string Name { get; set; } = null!;

        //public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

        public virtual ICollection<SubDepartment> SubDepartments { get; set; } = new List<SubDepartment>();

        //public virtual ICollection<EmpPunishment> EmpPunishmentIssuingDepartments { get; set; } = new List<EmpPunishment>();

        //public virtual ICollection<EmpPunishment> EmpPunishmentOrderDepartments { get; set; } = new List<EmpPunishment>();

        //public virtual ICollection<EmpReward> EmpRewards { get; set; } = new List<EmpReward>();
    }
}
