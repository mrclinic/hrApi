
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace hiastHRApi.Domain.Entities.Identity
{
    [Table("RolePermissions")]
    public class RolePermissions : AuditEntity
    {
        [ForeignKey("RoleId")]
        [Sieve(CanFilter = true, CanSort = true, Name = "RoleId")]
        public Guid RoleId { get; set; }        
        public virtual Role Role { get; set; }
        [Sieve(CanFilter = true, CanSort = true, Name = "PermissionId")]

        [ForeignKey("PermissionId")]
        public Guid PermissionId { get; set; }       
        public virtual Permission Permission { get; set; }
    }
}
