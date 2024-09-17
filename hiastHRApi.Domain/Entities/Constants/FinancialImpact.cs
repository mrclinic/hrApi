using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class FinancialImpact : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<PunishmentType> PunishmentTypes { get; set; } = new List<PunishmentType>();

        public virtual ICollection<EmpVacation> EmpVacations { get; set; } = new List<EmpVacation>();
    }
}