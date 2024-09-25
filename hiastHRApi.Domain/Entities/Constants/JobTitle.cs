
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class JobTitle : AuditEntity
    {
        public string Name { get; set; } = null!;

        public virtual ICollection<EmpEmploymentChange> EmpEmploymentChanges { get; set; } = new List<EmpEmploymentChange>();

        public virtual ICollection<EmpPartner> EmpPartners { get; set; } = new List<EmpPartner>();
    }
}