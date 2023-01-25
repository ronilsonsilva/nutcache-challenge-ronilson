using Nutcache.Domain.Contracts.DomainServices;
using Nutcache.Domain.Contracts.Repositories;
using Nutcache.Domain.DomainResponse;
using Nutcache.Employee.Domain.Entities;

namespace Nutcache.Domain.DomainServices
{
    public class DomainServices<TEntity> : IDomainServices<TEntity> where TEntity : EntityBase
    {
        #region [Properties]

        protected readonly IRepository<TEntity> _repository;

        #endregion

        #region [Constructors]

        public DomainServices(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        #endregion

        #region [Public Methods]

        public async Task<Response<TEntity>> Add(TEntity entity)
        {
            if (entity.Invalid)
                return new Response<TEntity>(entity, entity.Validate());

            return new Response<TEntity>(await this._repository.Add(entity));
        }

        public async Task<Response<TEntity>> Update(TEntity entity)
        {
            if (entity.Invalid)
                return new Response<TEntity>(entity, entity.Validate());

            return new Response<TEntity>(await this._repository.Update(entity));
        }

        public async Task<TEntity> Get(int id)
        {
            return await this._repository.Get(id);
        }

        public async Task<IList<TEntity>> Get()
        {
            return await this._repository.Get();
        }

        public async Task<Response<bool>> Delete(int id)
        {
            return new Response<bool>(await this._repository.Delete(id));
        }

        #endregion
    }
}
