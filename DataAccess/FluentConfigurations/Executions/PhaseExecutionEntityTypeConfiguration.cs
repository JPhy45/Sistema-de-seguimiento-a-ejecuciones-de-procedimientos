using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Utilities;

namespace DataAccess.FluentConfigurations.Executions
{
    public class PhaseExecutionEntityTypeConfiguration : IEntityTypeConfiguration<PhaseExecution>
    {
        public void Configure(EntityTypeBuilder<PhaseExecution> builder)
        {
            builder.ToTable("PhaseExecution");
            builder.HasBaseType(typeof(Execution));
            builder.HasOne(PE => PE.Phase).
                WithMany().HasForeignKey(PE => PE.PhaseId);
        }
    }
}
