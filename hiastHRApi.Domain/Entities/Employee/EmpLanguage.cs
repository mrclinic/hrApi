
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpLanguage : AuditEntity
    {
        [Sieve(CanFilter = true, Name = "LanguageId")]
        public Guid LanguageId { get; set; }

        [Sieve(CanFilter = true, Name = "LanguageLevelId")]
        public Guid LanguageLevelId { get; set; }

        [Sieve(CanFilter = true, Name = "DisplayOnRecordCard")]
        public bool DisplayOnRecordCard { get; set; }

        public string Note { get; set; } = null!;

        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual Language Language { get; set; } = null!;

        public virtual LanguageLevel LanguageLevel { get; set; } = null!;
    }
}