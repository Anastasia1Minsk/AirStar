using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirStar.Data.Interfaces;
using AirStar.Infrastructure.Bases.Interfaces;
using AirStar.Models;
using Microsoft.EntityFrameworkCore;

namespace AirStar.Infrastructure.Bases
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseModel, new()
    {
        protected IDataContextFactory DataContextFactory;

        protected Func<IQueryable<TEntity>, IQueryable<TEntity>> OrderStrategy;
        protected List<string> Includes;

        protected RepositoryBase(IDataContextFactory dataContextFactory)
        {
            DataContextFactory = dataContextFactory;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await SelectOneAsync(x => x.Id == id);
        }

        public async Task<int> InsertAsync(TEntity model)
        {
            var result = await InsertAsync(new[] { model });
            return result.FirstOrDefault();
        }
        public async Task<IEnumerable<int>> InsertAsync(IEnumerable<TEntity> models)
        {
            using var context = DataContextFactory.Create();

            context.ChangeTracker.AutoDetectChangesEnabled = false;
            var table = context.Set<TEntity>();
            var records = models.ToList();
            await table.AddRangeAsync(records);
            context.ChangeTracker.DetectChanges();
            await context.SaveChangesAsync();
            return records.Select(r => r.Id);
        }

        public async Task<bool> UpdateAsync(TEntity model)
        {
            return await UpdateAsync(new[] { model });
        }
        public async Task<bool> UpdateAsync(IEnumerable<TEntity> models)
        {
            using var context = DataContextFactory.Create();

            context.ChangeTracker.AutoDetectChangesEnabled = false;
            var table = context.Set<TEntity>();
            table.UpdateRange(models);
            context.ChangeTracker.DetectChanges();
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TEntity>> SelectAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            List<string> includes = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> customOrderStrategy = null)
        {
            using var context = DataContextFactory.Create();
            return await GetQuery(context, predicate, includes, customOrderStrategy).ToListAsync();
        }

        public async Task<TEntity> SelectOneAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            List<string> includes = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> customOrderStrategy = null)
        {
            using var context = DataContextFactory.Create();
            return await GetQuery(context, predicate, includes, customOrderStrategy).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var model = new TEntity { Id = id };
            return await DeleteAsync(model);
        }
        public async Task<bool> DeleteAsync(IEnumerable<int> ids)
        {
            var models = ids.Select(x => new TEntity() { Id = x });
            return await DeleteAsync(models);
        }
        public async Task<bool> DeleteAsync(TEntity model)
        {
            return await DeleteAsync(new[] { model });
        }
        public async Task<bool> DeleteAsync(IEnumerable<TEntity> models)
        {
            using var context = DataContextFactory.Create();

            context.ChangeTracker.AutoDetectChangesEnabled = false;
            var table = context.Set<TEntity>();
            table.RemoveRange(models);
            context.ChangeTracker.DetectChanges();
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IPagedList<TEntity>> SelectPageAsync(int pageNumber = 1,
            int pageSize = 25,
            Expression<Func<TEntity, bool>> predicate = null,
            List<string> includes = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> customOrderStrategy = null)
        {
            using (var context = DataContextFactory.Create())
            {
                var query = GetQuery(context, predicate, includes, customOrderStrategy);
                var count = await query.CountAsync();
                var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

                return new PagedList<TEntity>(items, count, pageNumber, pageSize);
            }
        }

        IQueryable<TEntity> GetQuery(
            IDataContext context,
            Expression<Func<TEntity, bool>> predicate = null,
            List<string> includes = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> customOrderStrategy = null)
        {
            var query = context.Set<TEntity>().AsQueryable().AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }


            Includes?.ForEach(x =>
            {
                query = query.Include(x);
            });

            includes?.ForEach(x =>
            {
                query = query.Include(x);
            });


            var orderStrategy = customOrderStrategy ?? OrderStrategy;
            if (orderStrategy != null)
            {
                query = orderStrategy(query);
            }

            return query;
        }
    }
}
