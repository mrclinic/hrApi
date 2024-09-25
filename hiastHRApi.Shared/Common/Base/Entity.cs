using Sieve.Attributes;

namespace hiastHRApi.Shared.Base
{
    public class Entity
    {
        [Sieve(CanFilter = true, CanSort = true, Name = "Id")]
        public Guid Id { get; set; }
    }
}
