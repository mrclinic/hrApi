
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpExperience : AuditEntity
    {

        public Guid ExperienceTypeId { get; set; }

        public string Source { get; set; } = null!;

        public string Duration { get; set; } = null!;

        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual ExperienceType ExperienceType { get; set; } = null!;
    }
}