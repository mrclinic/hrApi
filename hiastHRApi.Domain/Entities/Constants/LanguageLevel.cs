﻿
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Shared.Base;

namespace hiastHRApi.Domain.Entities.Constants
{
    public partial class LanguageLevel : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpLanguage> EmpLanguages { get; set; } = new List<EmpLanguage>();
    }
}