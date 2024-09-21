using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class Qualification : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<Specialization> Specializations { get; set; } = new List<Specialization>();

        public virtual ICollection<EmpQualification> EmpQualifications { get; set; } = new List<EmpQualification>();
    }
}