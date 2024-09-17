using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Repository.Common.Result;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hiastHRApi.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<T> Get(Guid id);
        IEnumerable<T> GetAll(SieveModel sieveModel);
        IEnumerable<T> GetAll();
        Task<bool> Add(T entity);
        Task<bool> AddRange(IEnumerable<T> entities);
        bool Delete(Guid id);
        bool Update(T entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate, string includeProperties = "");
        bool DeleteMultiAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindSingle(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Get(SieveModel sieveModel, string includeProperties = "");
        IEnumerable<T> Get(SieveModel sieveModel, Expression<Func<T, bool>> predicate, string includeProperties = "");
        int GetMaxNo(Expression<Func<T, bool>> predicate, Func<T, decimal> columnSelector);
        GeneralResult<T> GetAllRecord(SieveModel sieveModel);
    }
}
