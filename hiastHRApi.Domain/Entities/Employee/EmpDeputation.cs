
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpDeputation : AuditEntity
    {

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public DateTime DeputationDecisionDate { get; set; }

        public DateTime ExecutiveContractDate { get; set; }

        public DateTime StartAfterReturnDate { get; set; }

        public Guid CountryId { get; set; }

        public Guid CityId { get; set; }

        public Guid UniversityId { get; set; }

        public Guid DeputationObjectiveId { get; set; }

        public Guid DeputationStatusId { get; set; }

        public Guid DeputationTypeId { get; set; }

        public string Duration { get; set; } = null!;

        public string DeputationDecisionNumber { get; set; } = null!;

        public string RequiredSpecialization { get; set; } = null!;

        public string ExecutiveContractNumber { get; set; } = null!;

        public string AssignedEntity { get; set; } = null!;

        public string DeputationReason { get; set; } = null!;

        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual City City { get; set; } = null!;

        public virtual Country Country { get; set; } = null!;

        public virtual DeputationObjective DeputationObjective { get; set; } = null!;

        public virtual DeputationStatus DeputationStatus { get; set; } = null!;

        public virtual DeputationType DeputationType { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual University University { get; set; } = null!;
    }
}