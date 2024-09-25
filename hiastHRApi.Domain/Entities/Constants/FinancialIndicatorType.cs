
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Shared.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class FinancialIndicatorType : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpReward> EmpRewards { get; set; } = new List<EmpReward>();
    }
}