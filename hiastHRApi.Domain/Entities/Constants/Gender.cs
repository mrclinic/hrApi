
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Shared.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class Gender : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpChild> EmpChildren { get; set; } = new List<EmpChild>();

        public virtual ICollection<EmpPartner> EmpPartners { get; set; } = new List<EmpPartner>();

        public virtual ICollection<EmpPersonalInfo> EmpPersonalInfos { get; set; } = new List<EmpPersonalInfo>();
    }
}