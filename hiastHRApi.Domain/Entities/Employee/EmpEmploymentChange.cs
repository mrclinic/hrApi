
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpEmploymentChange : AuditEntity
    {

        public DateTime DateOfAppointmentVisa { get; set; }

        public DateTime DateOfStart { get; set; }

        public DateTime DateOfChange { get; set; }

        public DateTime DateOfContract { get; set; }

        public int Salary { get; set; }

        public int InsuranceSalary { get; set; }

        public Guid JobChangeReasonId { get; set; }

        public Guid ModificationContractTypeId { get; set; }

        public Guid JobTitleId { get; set; }

        public string Workplace { get; set; } = null!;

        public string VisaNumber { get; set; } = null!;

        public string ContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual JobChangeReason JobChangeReason { get; set; } = null!;

        public virtual JobTitle JobTitle { get; set; } = null!;

        public virtual ModificationContractType ModificationContractType { get; set; } = null!;
    }
}