
using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class DocType : AuditEntity
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<EmpDoc> EmpDocs { get; set; } = new List<EmpDoc>();

    }
}
