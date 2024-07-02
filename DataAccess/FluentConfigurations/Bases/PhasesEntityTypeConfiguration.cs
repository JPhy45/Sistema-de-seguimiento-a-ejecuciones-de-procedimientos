using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities;

namespace DataAccess.FluentConfigurations.Bases
{
    public class PhasesEntityTypeConfiguration : IEntityTypeConfiguration<Phases>
    {
        public void Configure(EntityTypeBuilder<Phases> builder)
        {
            builder.ToTable("Phases");
            builder.HasBaseType(typeof(Base));
        }
    }
}
