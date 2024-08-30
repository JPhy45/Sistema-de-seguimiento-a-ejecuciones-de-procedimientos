using DataAccess.FluentConfigurations.Common;
using Domain.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.FluentConfigurations.Executions
{
    public class ExecutionEntityTypeConfiguration : EntityTypeConfigurationBase<Execution>
    {
        public override void Configure(EntityTypeBuilder<Execution> builder)
        {
            builder.ToTable("Execution");
            base.Configure(builder);
        }
    }
}
