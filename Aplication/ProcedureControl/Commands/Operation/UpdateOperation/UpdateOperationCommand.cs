using System.Text;
using System.Threading.Tasks;
using Aplication.Abstract;
using Domain.Domain.Entities;

namespace Aplication.ProcedureControl.Commands.Operation.UpdateOperation
{
    public record class UpdateOperationCommand(Operations Operation) : ICommand;
}
