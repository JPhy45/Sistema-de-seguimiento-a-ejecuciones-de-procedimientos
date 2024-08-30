using Aplication.Abstract;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ProcedureControl.Queries.GetUnitById
{
    public record GetUnitByIdQuery(Guid Id) : IQuery<UnitProcedure?>;
}

