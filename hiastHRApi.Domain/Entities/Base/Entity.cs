using Sieve.Attributes;

namespace hiastHRApi.Domain.Entities.Base
{
    public class Entity
    {
        [Sieve(CanFilter = true, CanSort = true, Name = "Id")]
        public Guid Id { get; set; }
    }
}
