
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpAppointmentStatus : AuditEntity
    {

        public DateOnly DateOfAppointmentDecision { get; set; }

        public DateOnly DateOfAppointmentVisa { get; set; }

        public DateOnly DateOfModifiedAppointmentVisaDate { get; set; }

        public DateOnly DateOfInsuranceStart { get; set; }

        public int GeneralRegistryNumber { get; set; }

        public Guid InsuranceSystemId { get; set; }

        public int EngineersSyndicateNumber { get; set; }

        public Guid AppointmentContractTypeId { get; set; }

        public Guid LawId { get; set; }

        public Guid HealthyStatusId { get; set; }

        public Guid DisabilityTypeId { get; set; }

        public Guid JobCategoryId { get; set; }

        public Guid ModificationContractTypeId { get; set; }

        public Guid StartingTypeId { get; set; }

        public string InsuranceNumber { get; set; } = null!;

        public string AppointmenContractNumber { get; set; } = null!;

        public string AppointmentContractVisaNumber { get; set; } = null!;

        public string ModifiedAppointmentContractNumber { get; set; } = null!;


        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual ModificationContractType AppointmentContractType { get; set; } = null!;

        public virtual DisabilityType DisabilityType { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual HealthyStatus HealthyStatus { get; set; } = null!;

        public virtual InsuranceSystem InsuranceSystem { get; set; } = null!;

        public virtual JobCategory JobCategory { get; set; } = null!;

        public virtual Law Law { get; set; } = null!;

        public virtual ModificationContractType ModificationContractType { get; set; } = null!;

        public virtual StartingType StartingType { get; set; } = null!;
    }
}