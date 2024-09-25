
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpLanguage : AuditEntity
    {

        public Guid LanguageId { get; set; }

        public Guid LanguageLevelId { get; set; }

        public bool DisplayOnRecordCard { get; set; }

        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual Language Language { get; set; } = null!;

        public virtual LanguageLevel LanguageLevel { get; set; } = null!;
    }
}