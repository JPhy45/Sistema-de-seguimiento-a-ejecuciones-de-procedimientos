using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Utilities;

namespace DataAccess.FluentConfigurations.Executions
{
    public class OperationExecutionEntityTypeConfiguration : IEntityTypeConfiguration<OperationExecution>
    {
        public void Configure(EntityTypeBuilder<OperationExecution> builder)
        {
            builder.ToTable("OperationExecution");
            builder.HasBaseType(typeof(Execution));
            builder.HasOne(OE => OE.Operation).
                WithMany().HasForeignKey(PE => PE.OperationId);
        }
    }
}
