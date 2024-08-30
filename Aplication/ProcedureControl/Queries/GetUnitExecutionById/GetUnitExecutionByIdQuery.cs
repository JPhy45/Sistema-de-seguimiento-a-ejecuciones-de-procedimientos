using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Abstract;
using Domain.Domain.Entities;
using Domain.Domain.Utilities;

namespace Aplication.ProcedureControl.Queries.GetUnitExecutionById
{
    public record GetUnitExecutionByIdQuery(Guid Id) : IQuery<UnitExecution?>;
}

