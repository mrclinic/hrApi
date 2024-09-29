

using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class SubDepartment : AuditEntity
    {

        public Guid DepartmentId { get; set; }

        public string Name { get; set; } = null!;

        //public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

        public virtual Department Department { get; set; } = null!;
    }
}
