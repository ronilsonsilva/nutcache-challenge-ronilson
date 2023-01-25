using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nutcache.Infra.Data.Context.Mappings
{
    internal class EmplopyeeMap : BaseMap<Domain.Entities.Employee>
    {
        public EmplopyeeMap(string nomeTabela = "Employee") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<Domain.Entities.Employee> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(512).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();


            base.Configure(builder);
        }
    }
}
