
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpPerformanceEvaluation : AuditEntity
    {

        public DateTime ReportDate { get; set; }

        public DateTime PromotionDate { get; set; }

        public Guid EvaluationGradeId { get; set; }

        public Guid EvaluationQuarterId { get; set; }

        public string ReportNumber { get; set; } = null!;


        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual EvaluationGrade EvaluationGrade { get; set; } = null!;

        public virtual EvaluationQuarter EvaluationQuarter { get; set; } = null!;
    }
}