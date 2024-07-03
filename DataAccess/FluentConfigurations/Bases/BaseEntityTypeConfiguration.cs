using DataAccess.FluentConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities;

namespace DataAccess.FluentConfigurations.Bases
{
    public class BaseEntityTypeConfiguration : EntityTypeConfigurationBase<Base>
    {
        public override void Configure(EntityTypeBuilder<Base> builder)
        {
            builder.ToTable("Base");
            base.Configure(builder);
            builder.Property(B => B.Description).IsRequired(false);
        }
    }
}
