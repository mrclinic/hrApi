

using hiastHRApi.Shared.Base;

namespace hiastHRApi.Domain.Entities.Constants
{
    public partial class TerminationReason : AuditEntity
    {

        public string Name { get; set; } = null!;
    }
}