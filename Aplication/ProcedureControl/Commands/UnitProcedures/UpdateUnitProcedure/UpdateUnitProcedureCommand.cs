using System.Text;
using System.Threading.Tasks;
using Aplication.Abstract;
using Domain.Domain.Entities;


namespace Aplication.ProcedureControl.Commands.UnitProcedures.UpdateUnitProcedure
{
    public record class UpdateUnitProcedureCommand(UnitProcedure UnitProcedure) : ICommand;
}