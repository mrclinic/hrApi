
using hiastHRApi.Shared.Base;
using hiastHRApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using System.Linq.Expressions;
using hiastHRApi.Shared.Common.Result;

namespace hiastHRApi.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected HrmappContext context;
        internal DbSet<T> dbSet;
        private readonly SieveProcessor _sieveProcessor;

        public GenericRepository(HrmappContext context, SieveProcessor sieveProcessor)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            _sieveProcessor = sieveProcessor;
        }
        public virtual async Task<T> Get(Guid id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            var result = dbSet.AsNoTracking(); // Makes read-only queries faster
            return result.ToList();
        }
        public virtual IEnumerable<T> GetAll(SieveModel sieveModel)
        {
            var result = dbSet.AsNoTracking(); // Makes read-only queries faster
            result = _sieveProcessor.Apply(sieveModel, result); // Returns `result` after applying the sort/filter/page query in `SieveModel` to it
            return result.ToList();
        }
        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual bool Delete(Guid id)
        {
            T entity = dbSet.Find(id);
            dbSet.Remove(entity);
            return true;
        }
        public virtual bool DeleteMultiAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = dbSet.Where(predicate).ToList();
            dbSet.RemoveRange(entities);
            return true;
        }
        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public virtual bool Update(T entity)
        {
            dbSet.Update(entity);
            return true;
        }

        public async Task<T> FindSingle(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual async Task<bool> AddRange(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return true;
        }

        public virtual IEnumerable<T> Get(SieveModel sieveModel, string includeProperties = "")
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            query = _sieveProcessor.Apply(sieveModel, query);
            return query.ToList();
        }

        public virtual int GetMaxNo(Expression<Func<T, bool>> predicate, Func<T, decimal> columnSelector)
        {
            return dbSet.Where(predicate).Select(columnSelector).Count() > 0 ? (int)dbSet.Where(predicate).Select(columnSelector)?.Max() + 1 : -1;
        }

        public IEnumerable<T> Get(SieveModel sieveModel, Expression<Func<T, bool>> predicate, string includeProperties = "")
        {
            IQueryable<T> query = dbSet.Where(predicate).AsNoTracking();

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            //var result = dbSet.AsNoTracking(); // Makes read-only queries faster
            query = _sieveProcessor.Apply(sieveModel, query); // Returns `result` after applying the sort/filter/page query in `SieveModel` to it
            return query.ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate, string includeProperties = "")
        {
            IQueryable<T> query = dbSet.Where(predicate).AsNoTracking();

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }

        public GeneralResult<T> GetAllRecord(SieveModel sieveModel)
        {
            var result = dbSet.AsNoTracking(); // Makes read-only queries faster
            var count = result.Count();
            result = _sieveProcessor.Apply(sieveModel, result); // Returns `result` after applying the sort/filter/page query in `SieveModel` to it
            return new GeneralResult<T> { RecordCount = count, Data = result.ToList(), IsSuccess = true, MSG = "done" };
        }
    }
}
