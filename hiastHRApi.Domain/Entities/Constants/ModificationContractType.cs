
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Shared.Base;

namespace hiastHRApi.Domain.Entities.Constants
{

    public partial class ModificationContractType : AuditEntity
    {


        public string Name { get; set; } = null!;

        public virtual ICollection<JobChangeReason> JobChangeReasons { get; set; } = new List<JobChangeReason>();

        public virtual ICollection<EmpAppointmentStatus> EmpAppointmentStatusAppointmentContractTypes { get; set; } = new List<EmpAppointmentStatus>();

        public virtual ICollection<EmpAppointmentStatus> EmpAppointmentStatusModificationContractTypes { get; set; } = new List<EmpAppointmentStatus>();

        public virtual ICollection<EmpAssignment> EmpAssignments { get; set; } = new List<EmpAssignment>();

        public virtual ICollection<EmpEmploymentChange> EmpEmploymentChanges { get; set; } = new List<EmpEmploymentChange>();

        public virtual ICollection<EmpEmploymentStatus> EmpEmploymentStatuses { get; set; } = new List<EmpEmploymentStatus>();

        public virtual ICollection<EmpPunishment> EmpPunishments { get; set; } = new List<EmpPunishment>();

        public virtual ICollection<EmpRelinquishment> EmpRelinquishments { get; set; } = new List<EmpRelinquishment>();

        public virtual ICollection<EmpReward> EmpRewards { get; set; } = new List<EmpReward>();

        public virtual ICollection<EmpTrainingCourse> EmpTrainingCourses { get; set; } = new List<EmpTrainingCourse>();

        public virtual ICollection<EmpVacation> EmpVacationContractTypes { get; set; } = new List<EmpVacation>();

        public virtual ICollection<EmpVacation> EmpVacationModificationContractTypes { get; set; } = new List<EmpVacation>();

        public virtual ICollection<EmpWorkPlace> EmpWorkPlaces { get; set; } = new List<EmpWorkPlace>();
    }
}
