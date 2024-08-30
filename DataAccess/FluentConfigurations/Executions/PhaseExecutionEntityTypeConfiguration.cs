using Domain.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
