
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class PromotionPercentage : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpPromotion> EmpPromotions { get; set; } = new List<EmpPromotion>();
    }
}