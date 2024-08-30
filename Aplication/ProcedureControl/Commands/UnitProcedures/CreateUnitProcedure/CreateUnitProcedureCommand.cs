using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Entities;
using Domain.Domain.Type;
using Aplication.Abstract;


namespace Aplication.ProcedureControl.Commands.UnitProcedures.CreateUnitProcedure
{
    public record CreateUnitProcedureCommand(
        string IC,
        string Name) : ICommand<UnitProcedure>;
}

