﻿using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Domain.Entities.Employee;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class Law : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<EmpAppointmentStatus> EmpAppointmentStatuses { get; set; } = new List<EmpAppointmentStatus>();
    }
}