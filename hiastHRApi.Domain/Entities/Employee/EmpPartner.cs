
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpPartner : AuditEntity
    {

        public DateTime? BirthDate { get; set; }

        public DateTime? OccurrenceDate { get; set; }

        public int PartnerOrder { get; set; }

        public Guid GenderId { get; set; }

        public Guid NationalityId { get; set; }

        public Guid PartnerWorkId { get; set; }

        public string MotherName { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string OccurrenceContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public Guid OccurrenceTypeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual Gender Gender { get; set; } = null!;

        public virtual Nationality Nationality { get; set; } = null!;

        public virtual OccurrencePartnerType OccurrenceType { get; set; } = null!;

        public virtual JobTitle PartnerWork { get; set; } = null!;
    }
}