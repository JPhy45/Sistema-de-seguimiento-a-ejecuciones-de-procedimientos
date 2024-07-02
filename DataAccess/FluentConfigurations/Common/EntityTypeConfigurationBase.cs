using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Common;

namespace DataAccess.FluentConfigurations.Common
{
    public abstract class EntityTypeConfigurationBase<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
