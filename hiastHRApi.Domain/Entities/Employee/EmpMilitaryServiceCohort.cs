﻿


using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;

namespace hiastHRApi.Domain.Entities.Employee
{
    public partial class EmpMilitaryServiceCohort : AuditEntity
    {

        public DateOnly StartDate { get; set; }

        public DateOnly StartContractDate { get; set; }

        public DateOnly EndDate { get; set; }

        public DateOnly EndContractDate { get; set; }

        public string StartContractNumber { get; set; } = null!;

        public string EndContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual EmpPersonalInfo Employee { get; set; } = null!;
    }
}