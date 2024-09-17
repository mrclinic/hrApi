﻿using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class PunishmentType : AuditEntity
    {
        public Guid FinancialImpactId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<EmpPunishment> EmpPunishments { get; set; } = new List<EmpPunishment>();

        public virtual FinancialImpact FinancialImpact { get; set; } = null!;
    }
}