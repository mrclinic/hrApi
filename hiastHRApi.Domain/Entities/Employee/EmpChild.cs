
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpChild : AuditEntity
    {

        public DateTime? BirthDate { get; set; }

        public DateTime? OccurrenceDate { get; set; }

        public int ChildOrder { get; set; }

        public Guid GenderId { get; set; }

        public Guid StatusId { get; set; }

        public string Name { get; set; } = null!;

        public string MotherName { get; set; } = null!;

        public string OccurrenceContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual Gender Gender { get; set; } = null!;

        public virtual ChildStatus Status { get; set; } = null!;
    }
}
