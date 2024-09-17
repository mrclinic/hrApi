using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class MilitarySpecialization : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpMilitaryService> EmpMilitaryServices { get; set; } = new List<EmpMilitaryService>();
    }
}