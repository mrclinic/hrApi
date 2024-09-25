
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class RewardType : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpReward> EmpRewards { get; set; } = new List<EmpReward>();
    }
}