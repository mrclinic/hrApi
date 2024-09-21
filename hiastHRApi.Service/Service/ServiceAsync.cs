using AutoMapper;
using hiastHRApi.Domain.Entities.Base;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Services.Common.Models;
using hiastHRApi.Services.Common.Result;
using hiastHRApi.Services.IService;
using Sieve.Models;
using System.Linq.Expressions;

namespace hiastHRApi.Service.Service
{
    public class ServiceAsync<TEntity, TDto> : IServiceAsync<TEntity, TDto>
        where TDto : EntityDto where TEntity : Entity
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public ServiceAsync(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Add(TDto tDto)
        {

            var entity = _mapper.Map<TEntity>(tDto);
            await _repository.Add(entity);
        }

        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<TDto> GetAll()
        {
            return _repository.GetAll().Select(_mapper.Map<TDto>).ToList();
        }
        public IEnumerable<TDto> GetAll(SieveModel sieveModel)
        {
            return _repository.GetAll(sieveModel).Select(_mapper.Map<TDto>).ToList();
        }

        public async Task<TDto> Get(Guid id)
        {
            var entity = await _repository.Get(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.Get(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<IEnumerable<TDto>> Find(Expression<Func<TDto, bool>> expression)
        {
            var predicate = _mapper.Map<Expression<Func<TEntity, bool>>>(expression);
            var entity = await _repository.Find(predicate);
            return _mapper.Map<IEnumerable<TDto>>(entity);
        }

        public async Task<TDto> Update(TDto entityTDto)
        {
            var entity = _mapper.Map<TEntity>(entityTDto);
            _repository.Update(entity);
            entity = await _repository.Get(entityTDto.Id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task AddRange(IEnumerable<TDto> tDtos)
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(tDtos);
            await _repository.AddRange(entities);
        }

        public IEnumerable<TDto> Get(SieveModel sieveModel, string includeProperties = "")
        {
            return _repository.Get(sieveModel, includeProperties).Select(_mapper.Map<TDto>).ToList();
        }

        public bool DeleteMultiAsync(Expression<Func<TDto, bool>> expression)
        {
            var predicate = _mapper.Map<Expression<Func<TEntity, bool>>>(expression);
            return _repository.DeleteMultiAsync(predicate);
        }

        public IEnumerable<TDto> Get(SieveModel sieveModel, Expression<Func<TDto, bool>> expression, string includeProperties = "")
        {
            var predicate = _mapper.Map<Expression<Func<TEntity, bool>>>(expression);
            var entity = _repository.Get(sieveModel, predicate, includeProperties);
            return _mapper.Map<IEnumerable<TDto>>(entity);
        }

        public GeneralResultDto<TDto> GetAllRecord(SieveModel sieveModel)
        {
            var res = _repository.GetAllRecord(sieveModel);
            return new GeneralResultDto<TDto> { Data = res.Data.Select(_mapper.Map<TDto>).ToList(), MSG = res.MSG, IsSuccess = res.IsSuccess, RecordCount = res.RecordCount };
        }
    }
}