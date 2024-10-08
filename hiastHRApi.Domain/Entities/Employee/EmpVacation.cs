﻿
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Base;
using Sieve.Attributes;


namespace hiastHRApi.Domain.Entities.Employee
{
    public partial class EmpVacation : AuditEntity
    {

        public DateTime StartDate { get; set; }

        public DateTime ContractDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime ModificationContractDate { get; set; }

        public DateTime ActualReturnDate { get; set; }

        public int DurationInDays { get; set; }

        public Guid VacationTypeId { get; set; }

        public int VacationYear { get; set; }

        public Guid ContractTypeId { get; set; }

        public bool IsAppearingInRecordCard { get; set; }

        public Guid FinancialImpactId { get; set; }

        public Guid ForcedVacationTypeId { get; set; }

        public bool IsIncludedInServiceDuration { get; set; }

        public Guid ModificationContractTypeId { get; set; }

        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public string ContractNumber { get; set; } = null!;

        public string ModificationContractNumber { get; set; } = null!;

        public string Note { get; set; } = null!;
        [Sieve(CanFilter = true, Name = "EmployeeId")]
        public Guid EmployeeId { get; set; }

        public virtual ModificationContractType ContractType { get; set; } = null!;

        public virtual EmpPersonalInfo Employee { get; set; } = null!;

        public virtual FinancialImpact FinancialImpact { get; set; } = null!;

        public virtual ForcedVacationType ForcedVacationType { get; set; } = null!;

        public virtual ModificationContractType ModificationContractType { get; set; } = null!;

        public virtual VacationType VacationType { get; set; } = null!;
    }
}