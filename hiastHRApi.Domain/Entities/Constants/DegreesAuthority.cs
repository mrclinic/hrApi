
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public  class DegreesAuthority : AuditEntity
    {
        public string Name { get; set; } = null!;

        public virtual ICollection<EmpQualification> EmpQualifications { get; set; } = new List<EmpQualification>();
    }
}