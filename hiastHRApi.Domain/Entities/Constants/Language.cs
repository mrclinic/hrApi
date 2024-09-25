
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class Language : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpLanguage> EmpLanguages { get; set; } = new List<EmpLanguage>();
    }
}