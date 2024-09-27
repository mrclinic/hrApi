using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Constants
{
    public class Branch : AuditEntity
    {
        public Guid OrgDepartmentId { get; set; }
        public string Name { get; set; } = null!;
        public virtual OrgDepartment OrgDepartment { get; set; } = null!;
    }

}