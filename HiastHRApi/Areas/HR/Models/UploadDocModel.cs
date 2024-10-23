using hiastHRApi.Domain.Entities.Constants;

namespace hiastHRApi.Areas.HR.Models
{
    public class UploadDocModel
    {
        public DateTime? DocDate { get; set; }
        public string? DocNumber { get; set; } = string.Empty;
        public string? DocSrc { get; set; } = string.Empty;
        public string? DocDescription { get; set; } = string.Empty;
        public IFormFile[] Files { get; set; }
        public Guid DocTypeId { get; set; }
        public string? Note { get; set; } = null!;
        public virtual DocType? DocType { get; set; } = null!;
        public Guid? RefId { get; set; }
        public Guid PersonId { get; set; }

    }
}
