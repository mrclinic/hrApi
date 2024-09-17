
using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;
using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hiastHRApi.Domain.Entities.Constants
{
    [Table("Countries")]
    public class Country : AuditEntity
    {
        [StringLength(100)]
        [Required]
        [Sieve(CanFilter = true, CanSort = true, Name = "Name")]
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();
        public ICollection<EmpDeputation> EmpDeputations { get; set; } = new List<EmpDeputation>();
        public ICollection<EmpQualification> EmpQualifications { get; set; } = new List<EmpQualification>();
    }
}