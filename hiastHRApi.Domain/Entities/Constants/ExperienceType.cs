﻿using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class ExperienceType : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpExperience> EmpExperiences { get; set; } = new List<EmpExperience>();
    }
}