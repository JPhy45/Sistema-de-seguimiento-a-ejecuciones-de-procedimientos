using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
