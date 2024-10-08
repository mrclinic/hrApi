﻿
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class JobChangeReason : AuditEntity
    {
        public Guid ModificationContractTypeId { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<EmpEmploymentChange> EmpEmploymentChanges { get; set; } = new List<EmpEmploymentChange>();

        public virtual ModificationContractType ModificationContractType { get; set; } = null!;
    }
}
