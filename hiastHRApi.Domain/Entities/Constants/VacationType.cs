﻿
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Constants
{
    public partial class VacationType : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpVacation> EmpVacations { get; set; } = new List<EmpVacation>();
    }
}
