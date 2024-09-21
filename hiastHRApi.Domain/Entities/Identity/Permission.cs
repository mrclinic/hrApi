using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hiastHRApi.Domain.Entities.Identity
{
    [Table("Permissions")]
    public class Permission : AuditEntity
    {
        [Required]
        [StringLength(500)]
        [Sieve(CanFilter = true, CanSort = true, Name = "NAME")]
        public string NAME { get; set; }
        [Sieve(CanFilter = true, CanSort = true, Name = "ORDER")]
        public int ORDER { get; set; }
        [Required]
        [Sieve(CanFilter = true, CanSort = true, Name = "DisplayName")]
        public string DisplayName { get; set; }
    }
}
