


using hiastHRApi.Shared.Base;

namespace hiastHRApi.Domain.Entities.Constants
{
    public partial class OrgDepartment : AuditEntity
    {
        public string Name { get; set; } = null!;
        public Guid? ParentId { get; set; }
        public OrgDepartment Parent { get; set; }
        public ICollection<OrgDepartment> SubOrgDepartments { get; } = new List<OrgDepartment>();
    }
}
