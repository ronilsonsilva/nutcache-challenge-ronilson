using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nutcache.Employee.Domain.Entities;

namespace Nutcache.Infra.Data.Context.Mappings
{
    internal class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        protected readonly string _nomeTabela;
        public BaseMap(string nomeTabela)
        {
            this._nomeTabela = nomeTabela;
        }
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(this._nomeTabela);
            builder.HasKey(x => x.Id);
        }
    }
}
