
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;


namespace hiastHRApi.Domain.Entities.Employee
{

    public partial class EmpPromotion : AuditEntity
    {

        public DateTime PromotionDate { get; set; }

        public int PromotionDuration { get; set; }

        public Guid EvaluationGradeId { get; set; }

        public decimal NewSalary { get; set; }

        public decimal BonusAmount { get; set; }

        public Guid PromotionPercentageId { get; set; }

        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual EvaluationGrade EvaluationGrade { get; set; } = null!;

        public virtual PromotionPercentage PromotionPercentage { get; set; } = null!;
    }
}