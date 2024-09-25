
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Shared.Base;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpPerformanceEvaluation : AuditEntity
    {

        public DateOnly ReportDate { get; set; }

        public DateOnly PromotionDate { get; set; }

        public Guid EvaluationGradeId { get; set; }

        public Guid EvaluationQuarterId { get; set; }

        public string ReportNumber { get; set; } = null!;


        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual EvaluationGrade EvaluationGrade { get; set; } = null!;

        public virtual EvaluationQuarter EvaluationQuarter { get; set; } = null!;
    }
}