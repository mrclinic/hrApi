using System.Collections.Generic;

namespace hiastHRApi.Services.Common.Result
{
    public class GeneralResultDto<TDto>
    {
        public int RecordCount { get; set; }
        public List<TDto> Data { get; set; } = new List<TDto>();
        public bool IsSuccess { get; set; }
        public string MSG { get; set; } = String.Empty;
    }
}
