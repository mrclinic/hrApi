
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;


namespace hiastHRApi.Domain.Entities.Employee
{
    public partial class EmpTrainingCourse : AuditEntity
    {

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public DateOnly ContractDate { get; set; }

        public Guid ContractTypeId { get; set; }

        public bool DisplayOnRecordCard { get; set; }

        public string CourseName { get; set; } = null!;

        public string CourseSource { get; set; } = null!;

        public string ContractNumber { get; set; } = null!;
        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual ModificationContractType ContractType { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;
    }
}