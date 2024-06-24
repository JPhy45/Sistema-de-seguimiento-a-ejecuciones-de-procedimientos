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
using System.Security.Cryptography.X509Certificates;

namespace DataAccess.FluentConfigurations.Bases
{
    public class UnitProcedureEntityTypeConfiguration : IEntityTypeConfiguration<UnitProcedure>
    {
        public void Configure(EntityTypeBuilder<UnitProcedure> builder)
        {
            builder.ToTable("Procedimientos");
            builder.HasBaseType(typeof(Base));
        }
    }
}
