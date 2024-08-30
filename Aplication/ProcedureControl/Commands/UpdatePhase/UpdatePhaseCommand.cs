using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Abstract;
using Domain.Domain.Entities;

namespace Aplication.ProcedureControl.Commands.UpdatePhase
{
    public record class UpdatePhaseCommand(Phases Phase) : ICommand;
}
