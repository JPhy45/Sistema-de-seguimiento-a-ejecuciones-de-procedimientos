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
using Microsoft.EntityFrameworkCore;

namespace DataAccess.FluentConfigurations.Bases
{
    public class BaseEntityTypeConfiguration : EntityTypeConfigurationBase<Base>
    {
        public override void Configure(EntityTypeBuilder<Base> builder)
        {
            builder.ToTable("Base");
            base.Configure(builder);
        }
    }
}
