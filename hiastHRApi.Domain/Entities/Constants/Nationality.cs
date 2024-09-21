﻿using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{
    public partial class Nationality : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpPartner> EmpPartners { get; set; } = new List<EmpPartner>();

        public virtual ICollection<EmpPersonalInfo> EmpPersonalInfos { get; set; } = new List<EmpPersonalInfo>();
    }
}