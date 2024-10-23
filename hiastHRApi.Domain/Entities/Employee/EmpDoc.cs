
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;

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
        public string? Note { get; set; } = string.Empty;
        public virtual DocType DocType { get; set; } = null!;

        [Sieve(CanFilter = true, Name = "RefId")]
        public Guid? RefId { get; set; }

        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public string FileType { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

    }
}