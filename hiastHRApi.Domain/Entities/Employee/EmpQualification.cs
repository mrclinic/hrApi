
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpQualification : AuditEntity
    {

        public DateOnly? DegreeDate { get; set; }

        public DateOnly? EquivalenceDegreeContractDate { get; set; }

        public Guid SpecializationId { get; set; }

        public Guid DegreesAuthorityId { get; set; }

        public Guid CountryId { get; set; }

        public Guid QualificationId { get; set; }

        public string SubSpecialization { get; set; } = null!;

        public string EquivalenceContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual Country Country { get; set; } = null!;

        public virtual DegreesAuthority DegreesAuthority { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual Qualification Qualification { get; set; } = null!;

        public virtual Specialization Specialization { get; set; } = null!;
    }
}