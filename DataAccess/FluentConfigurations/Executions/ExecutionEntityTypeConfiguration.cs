using DataAccess.FluentConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Domain.Utilities;

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
