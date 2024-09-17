using Microsoft.AspNetCore.Mvc;

namespace engApi.Areas.Guild.Models
{
    public class FileToDownload
    {
        public FileContentResult Data { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
    }
}
