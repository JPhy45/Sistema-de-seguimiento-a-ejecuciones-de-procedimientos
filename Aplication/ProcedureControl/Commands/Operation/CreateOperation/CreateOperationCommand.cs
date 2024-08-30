using Aplication.Abstract;
using Domain.Domain.Entities;
using Domain.Domain.Type;
using Domain.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ProcedureControl.Commands.Operation.CreateOperation
{
    public record CreateOperationCommand(
        string IC,
        string Name) : ICommand<Operations>;

}