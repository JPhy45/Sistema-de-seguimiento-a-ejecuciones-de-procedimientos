using Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.FluentConfigurations.Procedures
{
    public class PhasesEntityTypeConfiguration : IEntityTypeConfiguration<Phases>
    {
        public void Configure(EntityTypeBuilder<Phases> builder)
        {
            builder.ToTable("Phases");
            builder.HasBaseType(typeof(ProcedureControl));
        }
    }
}
