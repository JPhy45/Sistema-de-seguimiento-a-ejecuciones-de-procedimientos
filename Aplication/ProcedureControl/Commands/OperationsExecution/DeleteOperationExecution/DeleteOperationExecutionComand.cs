using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Abstract;

namespace Aplication.ProcedureControl.Commands.OperationsExecution.DeleteOperationExecution
{
    public record DeleteOperationExecutionCommand(Guid Id) : ICommand;
}
