
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;

namespace hiastHRApi.Domain.Entities.Employee
{
    public partial class EmpDoc : AuditEntity
    {
        public DateTime? DocDate { get; set; }
        public string? DocNumber { get; set; } = string.Empty;
        public string? DocSrc { get; set; } = string.Empty;
        public string? DocDescription { get; set; } = string.Empty;
        public byte[] Content { get; set; }

        [Sieve(CanFilter = true, Name = "DocTypeId")]
        public Guid DocTypeId { get; set; }
        public string? Note { get; set; } = null!;
        public virtual DocType DocType { get; set; } = null!;

        [Sieve(CanFilter = true, Name = "RefId")]
        public Guid? RefId { get; set; }

        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

    }
}