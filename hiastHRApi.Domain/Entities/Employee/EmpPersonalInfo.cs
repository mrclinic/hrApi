using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Constants;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpPersonalInfo : AuditEntity
    {

        public DateOnly? BirthDate { get; set; }

        public DateOnly? FamilyBookDate { get; set; }

        public string? ImagePath { get; set; }

        public Guid EmploymentStatusTypeId { get; set; }

        public Guid GenderId { get; set; }

        public Guid NationalityId { get; set; }

        public Guid MaritalStatusId { get; set; }

        public Guid BloodGroupId { get; set; }

        public Guid CityId { get; set; }

        public int? RegistrationNumber { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string FatherName { get; set; } = null!;

        public string MotherName { get; set; } = null!;

        public string BirthPlace { get; set; } = null!;

        public string? RegistrationPlaceAndNumber { get; set; }

        public string? Address { get; set; }

        public string? NationalNumber { get; set; }

        public string? Idnumber { get; set; }

        public string? CivilRegistry { get; set; }

        public string? FamilyBookNumber { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string Note { get; set; } = null!;

        public Guid IdentityUserId { get; set; }

        public virtual ICollection<EmpAppointmentStatus> EmpAppointmentStatuses { get; set; } = new List<EmpAppointmentStatus>();

        public virtual ICollection<EmpAssignment> EmpAssignments { get; set; } = new List<EmpAssignment>();

        public virtual ICollection<EmpChild> EmpChildren { get; set; } = new List<EmpChild>();

        public virtual ICollection<EmpDeputation> EmpDeputations { get; set; } = new List<EmpDeputation>();

        public virtual ICollection<EmpEmploymentChange> EmpEmploymentChanges { get; set; } = new List<EmpEmploymentChange>();

        public virtual ICollection<EmpEmploymentStatus> EmpEmploymentStatuses { get; set; } = new List<EmpEmploymentStatus>();

        public virtual ICollection<EmpExperience> EmpExperiences { get; set; } = new List<EmpExperience>();

        public virtual ICollection<EmpLanguage> EmpLanguages { get; set; } = new List<EmpLanguage>();

        public virtual ICollection<EmpMilitaryServiceCohort> EmpMilitaryServiceCohorts { get; set; } = new List<EmpMilitaryServiceCohort>();

        public virtual ICollection<EmpMilitaryServiceSuspension> EmpMilitaryServiceSuspensions { get; set; } = new List<EmpMilitaryServiceSuspension>();

        public virtual ICollection<EmpMilitaryService> EmpMilitaryServices { get; set; } = new List<EmpMilitaryService>();

        public virtual ICollection<EmpPartner> EmpPartners { get; set; } = new List<EmpPartner>();

        public virtual ICollection<EmpPerformanceEvaluation> EmpPerformanceEvaluations { get; set; } = new List<EmpPerformanceEvaluation>();

        public virtual ICollection<EmpPromotion> EmpPromotions { get; set; } = new List<EmpPromotion>();

        public virtual ICollection<EmpPunishment> EmpPunishments { get; set; } = new List<EmpPunishment>();

        public virtual ICollection<EmpQualification> EmpQualifications { get; set; } = new List<EmpQualification>();

        public virtual ICollection<EmpRelinquishment> EmpRelinquishments { get; set; } = new List<EmpRelinquishment>();

        public virtual ICollection<EmpReward> EmpRewards { get; set; } = new List<EmpReward>();

        public virtual ICollection<EmpTrainingCourse> EmpTrainingCourses { get; set; } = new List<EmpTrainingCourse>();

        public virtual ICollection<EmpVacation> EmpVacations { get; set; } = new List<EmpVacation>();

        public virtual ICollection<EmpWorkInjury> EmpWorkInjuries { get; set; } = new List<EmpWorkInjury>();

        public virtual ICollection<EmpWorkPlace> EmpWorkPlaces { get; set; } = new List<EmpWorkPlace>();

        public virtual BloodGroup BloodGroup { get; set; } = null!;

        public virtual City City { get; set; } = null!;

        public virtual EmploymentStatusType EmploymentStatusType { get; set; } = null!;

        public virtual Gender Gender { get; set; } = null!;

        public virtual MaritalStatus MaritalStatus { get; set; } = null!;

        public virtual Nationality Nationality { get; set; } = null!;
    }
}