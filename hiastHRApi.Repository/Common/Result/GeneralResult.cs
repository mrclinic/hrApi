using hiastHRApi.Domain.Entities.Base;
using System.Collections.Generic;

namespace hiastHRApi.Repository.Common.Result
{
    public class GeneralResult<T> where T : Entity
    {
        public int RecordCount { get; set; }
        public List<T> Data { get; set; }
        public bool IsSuccess { get; set; }
        public string MSG { get; set; }
    }
}
