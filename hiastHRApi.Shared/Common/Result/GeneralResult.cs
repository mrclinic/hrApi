
using hiastHRApi.Shared.Base;

namespace hiastHRApi.Shared.Common.Result
{
    public class GeneralResult<T> where T : Entity
    {
        public int RecordCount { get; set; }
        public List<T> Data { get; set; }
        public bool IsSuccess { get; set; }
        public string MSG { get; set; }
    }
}
