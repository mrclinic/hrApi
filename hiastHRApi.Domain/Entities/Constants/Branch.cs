using hiastHRApi.Shared.Base;

namespace hiastHRApi.Domain.Entities.Constants
{
    public class Branch : AuditEntity
    {
        public Guid DepartmentId { get; set; }
        public Guid SubDepartmentId { get; set; }
        public string Name { get; set; } = null!;
        public virtual Department Department { get; set; } = null!;
        public virtual SubDepartment SubDepartment { get; set; } = null!;
    }

}