﻿using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class StartingType : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpAppointmentStatus> EmpAppointmentStatuses { get; set; } = new List<EmpAppointmentStatus>();

        public virtual ICollection<EmpEmploymentStatus> EmpEmploymentStatuses { get; set; } = new List<EmpEmploymentStatus>();
    }
}