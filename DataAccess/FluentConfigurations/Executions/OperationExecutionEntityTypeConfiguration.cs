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
    public class OperationExecutionEntityTypeConfiguration : IEntityTypeConfiguration<OperationExecution>
    {
        public void Configure(EntityTypeBuilder<OperationExecution> builder)
        {
            builder.ToTable("OperationExecution");
            builder.HasBaseType(typeof(Execution));
            builder.HasOne(OE => OE.Operation).
                WithMany().HasForeignKey(PE => PE.OperationId);
        }
    }
}
