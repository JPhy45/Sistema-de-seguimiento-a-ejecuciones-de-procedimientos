using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Domain.Utilities;

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
