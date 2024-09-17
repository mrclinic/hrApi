﻿using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{
    public partial class DeputationStatus : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpDeputation> EmpDeputations { get; set; } = new List<EmpDeputation>();
    }
}
