using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Abstract;
using Domain.Domain.Entities;

namespace Aplication.ProcedureControl.Queries.GetAllUnit
{
    public record GetAllUnitQuery : IQuery<IEnumerable<UnitProcedure>>;
}