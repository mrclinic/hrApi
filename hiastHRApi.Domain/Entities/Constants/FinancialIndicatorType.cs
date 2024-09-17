using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class FinancialIndicatorType : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpReward> EmpRewards { get; set; } = new List<EmpReward>();
    }
}