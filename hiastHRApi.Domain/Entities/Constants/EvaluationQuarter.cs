using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class EvaluationQuarter : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpPerformanceEvaluation> EmpPerformanceEvaluations { get; set; } = new List<EmpPerformanceEvaluation>();
    }
}