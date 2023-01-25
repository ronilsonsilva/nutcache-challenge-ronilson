using Nutcache.Employee.Domain.Entities;

namespace Nutcache.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(int id);
        Task<TEntity> Get(int id);
        Task<IList<TEntity>> Get();
    }
}
