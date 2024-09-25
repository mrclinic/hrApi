
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class OccurrencePartnerType : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpPartner> EmpPartners { get; set; } = new List<EmpPartner>();
    }
}
