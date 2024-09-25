
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpChild : AuditEntity
    {

        public DateOnly? BirthDate { get; set; }

        public DateOnly? OccurrenceDate { get; set; }

        public int ChildOrder { get; set; }

        public Guid GenderId { get; set; }

        public Guid StatusId { get; set; }

        public string Name { get; set; } = null!;

        public string MotherName { get; set; } = null!;

        public string OccurrenceContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual Gender Gender { get; set; } = null!;

        public virtual ChildStatus Status { get; set; } = null!;
    }
}
