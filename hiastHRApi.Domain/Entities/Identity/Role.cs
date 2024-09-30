
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hiastHRApi.Domain.Entities.Identity
{
    [Table("Roles")]
    public class Role : AuditEntity
    {
        [StringLength(100)]
        [Required]
        [Sieve(CanFilter = true, CanSort = true, Name = "Name")]
        public string Name { get; set; }

        [StringLength(100)]
        [Required]
        [Sieve(CanFilter = true, CanSort = true, Name = "DisplayName")]
        public string DisplayName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
