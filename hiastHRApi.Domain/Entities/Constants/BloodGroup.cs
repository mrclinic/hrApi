
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Constants
{
    public class BloodGroup : AuditEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<EmpPersonalInfo> EmpPersonalInfos { get; set; } = new List<EmpPersonalInfo>();
    }
}
