using Microsoft.EntityFrameworkCore;
using Nutcache.Domain.Contracts.Repositories;
using Nutcache.Employee.Domain.Entities;
using Nutcache.Infra.Data.Context;
using System.Linq.Expressions;

namespace Nutcache.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly NutcacheContext _context;

        public RepositoryBase(NutcacheContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            this._context.Set<TEntity>().Add(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            this._context.Entry(entity).State = EntityState.Detached;
            await this._context.SaveChangesAsync();
            return entity;
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return this._context.Set<TEntity>().Where(expression).AsQueryable();
        }

        public virtual async Task<TEntity> Get(int id)
        {
            var entity = await this.Get(x => x.Id == id).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<IList<TEntity>> Get()
        {
            return await this._context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<bool> Delete(int id)
        {
            var entityRemover = await this.Get(id);
            if (entityRemover == null) return false;
            this._context.Set<TEntity>().Remove(entityRemover);
            return (await this._context.SaveChangesAsync()) > 0;
        }
    }
}
