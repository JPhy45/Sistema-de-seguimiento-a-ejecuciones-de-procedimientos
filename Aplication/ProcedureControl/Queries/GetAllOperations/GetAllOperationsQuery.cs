using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Abstract;
using Domain.Domain.Entities;

namespace Aplication.ProcedureControl.Queries.GetAllOperations
{
    public record GetAllOperationsQuery : IQuery<IEnumerable<Operations>>;
}
