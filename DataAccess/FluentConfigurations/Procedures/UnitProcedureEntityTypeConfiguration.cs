using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Domain.Entities;

namespace DataAccess.FluentConfigurations.Procedures
{
    public class UnitProcedureEntityTypeConfiguration : IEntityTypeConfiguration<UnitProcedure>
    {
        public void Configure(EntityTypeBuilder<UnitProcedure> builder)
        {
            builder.ToTable("Procedimientos");
            builder.HasBaseType(typeof(ProcedureControl));
            builder.HasMany(UP => UP.Operations).WithMany(O => O.UnitProcedures);
        }
    }
}
