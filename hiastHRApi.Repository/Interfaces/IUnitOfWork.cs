using System;
using System.Threading.Tasks;

namespace hiastHRApi.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task CompleteAsync();
    }
}
