using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Domain.Entities;

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
