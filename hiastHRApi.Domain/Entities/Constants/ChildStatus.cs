﻿
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Domain.Entities.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public class ChildStatus : AuditEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<EmpChild> EmpChildren { get; set; } = new List<EmpChild>();
    }
}
