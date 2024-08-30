using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Entities;
using Domain.Domain.Type;
using Aplication.Abstract;
using Domain.Domain.Utilities;

namespace Aplication.ProcedureControl.Commands.OperationsExecution.UpdateOperationExecution
{
    public record class UpdateOperationExecutionCommand(OperationExecution OperationExecution) : ICommand;
}
