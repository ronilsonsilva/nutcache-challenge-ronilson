using Nutcache.Domain.DomainResponse;
using Nutcache.Employee.Domain.Entities;

namespace Nutcache.Domain.Contracts.DomainServices
{
    public interface IDomainServices<TEntity> where TEntity : EntityBase
    {
        Task<Response<TEntity>> Add(TEntity entity);
        Task<Response<TEntity>> Update(TEntity entity);
        Task<Response<bool>> Delete(int id);
        Task<IList<TEntity>> Get();
        Task<TEntity> Get(int id);
    }
}
