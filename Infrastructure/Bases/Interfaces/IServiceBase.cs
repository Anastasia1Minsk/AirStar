using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirStar.Infrastructure.Bases.Interfaces
{
    public interface IServiceBase<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<int> InsertAsync(TEntity model);
        Task<IEnumerable<int>> InsertAsync(IEnumerable<TEntity> models);
        Task<bool> UpdateAsync(TEntity model);
        Task<bool> UpdateAsync(IEnumerable<TEntity> models);
        Task<bool> DeleteAsync(TEntity model);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(IEnumerable<TEntity> models);
        Task<bool> DeleteAsync(IEnumerable<int> ids);

        Task<IEnumerable<TEntity>> SelectAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            List<string> includes = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> customOrderStrategy = null);

        Task<TEntity> SelectOneAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            List<string> includes = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> customOrderStrategy = null);

        Task<IPagedList<TEntity>> SelectPageAsync(int pageNumber = 1,
            int pageSize = 25,
            Expression<Func<TEntity, bool>> predicate = null,
            List<string> includes = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> customOrderStrategy = null);
    }
}
