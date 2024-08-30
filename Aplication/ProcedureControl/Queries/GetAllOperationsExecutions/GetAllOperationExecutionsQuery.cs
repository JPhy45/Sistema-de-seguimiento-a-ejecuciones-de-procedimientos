using Aplication.Abstract;
using Contracts;
using Contracts.Procedures;
using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Utilities;
using Contracts.Executions;


namespace Aplication.ProcedureControl.Queries.GetAllOperationsExecutions
{
    public record GetAllOperationsExecutionQuery : IQuery<IEnumerable<OperationExecution>>;
}
