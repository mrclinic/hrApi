using hiastHRApi.Services.Common.Result;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hiastHRApi.Services.IService
{
    public interface IServiceAsync<TEntity, TDto>
    {
        Task Add(TDto tDto);
        Task AddRange(IEnumerable<TDto> tDtos);
        bool Delete(Guid id);
        IEnumerable<TDto> GetAll(SieveModel sieveModel);
        IEnumerable<TDto> GetAll();
        Task<TDto> Get(Guid id);
        Task<TDto> Update(TDto entityTDto);
        Task<IEnumerable<TDto>> Find(Expression<Func<TDto, bool>> expression);
        bool DeleteMultiAsync(Expression<Func<TDto, bool>> expression);
        IEnumerable<TDto> Get(SieveModel sieveModel, string includeProperties = "");
        IEnumerable<TDto> Get(SieveModel sieveModel, Expression<Func<TDto, bool>> expression, string includeProperties = "");

        GeneralResultDto<TDto> GetAllRecord(SieveModel sieveModel);
    }
}
