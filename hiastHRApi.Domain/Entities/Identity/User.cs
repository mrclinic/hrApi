
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hiastHRApi.Domain.Entities.Identity
{
    [Table("Users")]
    public class User : AuditEntity
    {
        public User()
        {
            CreationTime = System.DateTime.Now;
            IsDeleted = false;
        }

        [StringLength(100)]
        [Required]
        [Sieve(CanFilter = true, CanSort = true, Name = "FName")]
        public string FirstName { get; set; }

        [StringLength(100)]
        [Required]
        [Sieve(CanFilter = true, CanSort = true, Name = "LName")]
        public string LastName { get; set; }

        [StringLength(100)]
        [Required]
        [Sieve(CanFilter = true, CanSort = true, Name = "UserName")]
        public string Username { get; set; }

        [StringLength(100)]
        [Required]
        public string Password { get; set; }

        [Required]
        [MinLength(10),MaxLength(10)]
        [Sieve(CanFilter = true, CanSort = true, Name = "Phone")]
        public string Mobile { get; set; }

        [Required]
        [MinLength(11), MaxLength(11)]
        [Sieve(CanFilter = true, CanSort = true, Name = "NatNum")]
        public string NationalNumber { get; set; }

        [EmailAddress]
        [Required]
        [Sieve(CanFilter = true, CanSort = true, Name = "EmailAddress")]
        public string Email { get; set; }

        public string? Token { get; set; }
        [Required]
        [Sieve(CanFilter = true, CanSort = true, Name = "IsActive")]
        public bool IsActive { get; set; }

        [Required]
        [ForeignKey("RoleId")]
        [Sieve(CanFilter = true, CanSort = true, Name = "RoleID")]
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
