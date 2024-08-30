using DataAccess.FluentConfigurations.Common;
using Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.FluentConfigurations.Procedures
{
    public class ProcedureControlEntityTypeConfiguration : EntityTypeConfigurationBase<ProcedureControl>
    {
        public override void Configure(EntityTypeBuilder<ProcedureControl> builder)
        {
            builder.ToTable("ProcedureControl");
            base.Configure(builder);
            builder.Property(B => B.Description).IsRequired(false);
        }
    }
}
