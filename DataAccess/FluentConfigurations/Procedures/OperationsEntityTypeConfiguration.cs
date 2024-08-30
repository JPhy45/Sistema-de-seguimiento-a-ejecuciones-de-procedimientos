using Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.FluentConfigurations.Procedures
{
    public class OperationsEntityTypeConfiguration : IEntityTypeConfiguration<Operations>
    {
        public void Configure(EntityTypeBuilder<Operations> builder)
        {
            builder.ToTable("Operaciones");
            builder.HasBaseType(typeof(ProcedureControl));
            builder.HasMany(O => O.Phases).WithMany(P => P.operations);

        }
    }
}
