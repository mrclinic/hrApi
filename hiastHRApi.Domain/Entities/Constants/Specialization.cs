﻿using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class Specialization : AuditEntity
    {

        public Guid QualificationId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<EmpQualification> EmpQualifications { get; set; } = new List<EmpQualification>();

        public virtual Qualification Qualification { get; set; } = null!;
    }
}