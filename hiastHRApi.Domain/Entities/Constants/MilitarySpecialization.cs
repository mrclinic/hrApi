
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Shared.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class MilitarySpecialization : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpMilitaryService> EmpMilitaryServices { get; set; } = new List<EmpMilitaryService>();
    }
}