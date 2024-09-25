
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpMilitaryService : AuditEntity
    {

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public Guid MilitaryRankId { get; set; }

        public Guid MilitarySpecializationId { get; set; }

        public string MilitaryNumber { get; set; } = null!;

        public string ReserveNumber { get; set; } = null!;

        public string CohortNumber { get; set; } = null!;

        public string RecruitmentBranch { get; set; } = null!;

        public string RecruitmentNumber { get; set; } = null!;

        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual MilitaryRank MilitaryRank { get; set; } = null!;

        public virtual MilitarySpecialization MilitarySpecialization { get; set; } = null!;
    }
}