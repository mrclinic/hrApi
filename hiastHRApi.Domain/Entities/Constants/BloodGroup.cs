using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{
    public class BloodGroup : AuditEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<EmpPersonalInfo> EmpPersonalInfos { get; set; } = new List<EmpPersonalInfo>();
    }
}
