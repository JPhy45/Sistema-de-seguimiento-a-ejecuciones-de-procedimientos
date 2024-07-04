using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities;

namespace DataAccess.FluentConfigurations.Bases
{
    public class OperationsEntityTypeConfiguration : IEntityTypeConfiguration<Operations>
    {
        public void Configure(EntityTypeBuilder<Operations> builder)
        {
            builder.ToTable("Operaciones");
            builder.HasBaseType(typeof(Base));
            builder.HasMany(O => O.phases);

        }
    }
}
