using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Utilities;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Type;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Common;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities;
using DataAccess.FluentConfigurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.FluentConfigurations.Executions
{
    public class PhaseExecutionEntityTypeConfiguration : IEntityTypeConfiguration<PhaseExecution>
    {
        public void Configure(EntityTypeBuilder<PhaseExecution> builder)
        {
            builder.ToTable("Phases");
            builder.HasBaseType(typeof(Execution));
            builder.HasOne(PE => PE.Phase).
                WithMany().HasForeignKey(PE => PE.PhaseId);
        }
    }
}
