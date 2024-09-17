using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Constants;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpPromotion : AuditEntity
    {

        public DateOnly PromotionDate { get; set; }

        public int PromotionDuration { get; set; }

        public Guid EvaluationGradeId { get; set; }

        public decimal NewSalary { get; set; }

        public decimal BonusAmount { get; set; }

        public Guid PromotionPercentageId { get; set; }

        public string Note { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual EvaluationGrade EvaluationGrade { get; set; } = null!;

        public virtual PromotionPercentage PromotionPercentage { get; set; } = null!;
    }
}