using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Utilities;

namespace DataAccess.FluentConfigurations.Executions
{
    public class UnitExecutionEntityTypeConfiguration : IEntityTypeConfiguration<UnitExecution>
    {
        public void Configure(EntityTypeBuilder<UnitExecution> builder)
        {
            builder.ToTable("UnitExecution");
            builder.HasBaseType(typeof(Execution));
            builder.HasOne(UE => UE.Unit).
                WithMany().HasForeignKey(PE => PE.UnitId);
        }
    }
}
