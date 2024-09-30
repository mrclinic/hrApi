
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hiastHRApi.Domain.Entities.Identity
{
    [Table("UserProfiles")]
    public class UserProfile : AuditEntity
    {
        [Required]
        [StringLength(100)]
        [Sieve(CanFilter = true, CanSort = true, Name = "FatherName")]
        public string FatherName { get; set; }

        [Required]
        [StringLength(100)]
        [Sieve(CanFilter = true, CanSort = true, Name = "MotherName")]
        public string MotherName { get; set; }

        [Required]
        [StringLength(100)]
        [Sieve(CanFilter = true, CanSort = true, Name = "BirthPlace")]
        public string BirthPlace { get; set; }

        [Required]
        [Sieve(CanFilter = true, CanSort = true, Name = "BirthDate")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(10)]
        [Sieve(CanFilter = true, CanSort = true, Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [StringLength(100)]
        [Sieve(CanFilter = true, CanSort = true, Name = "Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        [Sieve(CanFilter = true, CanSort = true, Name = "PersonalCardNumber")]
        public string PersonalCardNumber { get; set;}        

        [Required]
        [ForeignKey("UserId")]
        [Sieve(CanFilter = true, CanSort = true, Name = "UserId")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
