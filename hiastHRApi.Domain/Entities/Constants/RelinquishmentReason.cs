using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class RelinquishmentReason : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpRelinquishment> EmpRelinquishments { get; set; } = new List<EmpRelinquishment>();
    }
}