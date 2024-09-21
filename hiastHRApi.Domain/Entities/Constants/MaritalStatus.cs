using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{
    public partial class MaritalStatus : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpPersonalInfo> EmpPersonalInfos { get; set; } = new List<EmpPersonalInfo>();
    }
}