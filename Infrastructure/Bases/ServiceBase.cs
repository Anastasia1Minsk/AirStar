using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirStar.Infrastructure.Bases.Interfaces;

namespace AirStar.Infrastructure.Bases
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity>
    {
        protected IRepositoryBase<TEntity> Repository;

        protected ServiceBase(IRepositoryBase<TEntity> repository)
        {
            Repository = repository;
        }

        public async Task<bool> DeleteAsync(TEntity model)
        {
            return await Repository.DeleteAsync(model);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await Repository.DeleteAsync(id);
        }

        public async Task<bool> DeleteAsync(IEnumerable<TEntity> models)
        {
            return await Repository.DeleteAsync(models);
        }

        public async Task<bool> DeleteAsync(IEnumerable<int> ids)
        {
            return await Repository.DeleteAsync(ids);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(TEntity model)
        {
            return await Repository.InsertAsync(model);
        }

        public async Task<IEnumerable<int>> InsertAsync(IEnumerable<TEntity> models)
        {
            return await Repository.InsertAsync(models);
        }

        public async Task<IEnumerable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> predicate = null, List<string> includes = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> customOrderStrategy = null)
        {
            return await Repository.SelectAsync(predicate, includes, customOrderStrategy);
        }

        public async Task<TEntity> SelectOneAsync(Expression<Func<TEntity, bool>> predicate = null, List<string> includes = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> customOrderStrategy = null)
        {
            return await Repository.SelectOneAsync(predicate, includes, customOrderStrategy);
        }

        public async Task<IPagedList<TEntity>> SelectPageAsync(int pageNumber = 1, int pageSize = 25, Expression<Func<TEntity, bool>> predicate = null, List<string> includes = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> customOrderStrategy = null)
        {
            return await Repository.SelectPageAsync(pageNumber, pageSize, predicate, includes, customOrderStrategy);
        }

        public async Task<bool> UpdateAsync(TEntity model)
        {
            return await Repository.UpdateAsync(model);
        }

        public async Task<bool> UpdateAsync(IEnumerable<TEntity> models)
        {
            return await Repository.UpdateAsync(models);
        }
    }
}
