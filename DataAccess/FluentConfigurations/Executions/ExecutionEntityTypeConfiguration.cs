using DataAccess.FluentConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Utilities;

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
