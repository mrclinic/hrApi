﻿
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;


namespace hiastHRApi.Domain.Entities.Employee
{
    public partial class EmpTrainingCourse : AuditEntity
    {

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime ContractDate { get; set; }

        public Guid ContractTypeId { get; set; }

        public bool DisplayOnRecordCard { get; set; }

        public string CourseName { get; set; } = null!;

        public string CourseSource { get; set; } = null!;

        public string ContractNumber { get; set; } = null!;
        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual ModificationContractType ContractType { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;
    }
}