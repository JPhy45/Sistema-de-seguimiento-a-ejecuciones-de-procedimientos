using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Abstract;
using Domain.Domain.Entities;
using Domain.Domain.Utilities;

namespace Aplication.ProcedureControl.Queries.GetOperationExecutionById
{
    public record GetOperationExecutionByIdQuery(Guid Id) : IQuery<OperationExecution?>;
}
