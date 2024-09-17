using hiastHRApi.Domain;
using hiastHRApi.Domain.Interfaces;
using System.Threading.Tasks;

namespace hiastHRApi.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HrmappContext _context;

        public UnitOfWork(HrmappContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
