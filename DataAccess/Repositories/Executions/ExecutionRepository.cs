using Contracts.Executions;
using DataAccess.Contexts;
using DataAccess.Repositories.Common;
using Domain.Domain.Utilities;

namespace DataAccess.Repositories.Executions
{
    public class ExecutionRepository : RepositoryBase, IExecutionRepository
    {
        public ExecutionRepository(AplicationContext context) : base(context) { }
        public void AddExecution(Execution Execution)
        {
            _context.Executions.Add(Execution);
        }
        public void DeleteExecution(Execution Execution)
        {
            _context.Executions.Remove(Execution);
        }
        public IEnumerable<T> GetAllExecutions<T>() where T : Execution
        {
            return _context.Set<T>().ToList();
        }
        public T? GetExecutionById<T>(Guid Id) where T : Execution
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == Id);
        }
        public void UpdateExecution(Execution Execution)
        {
            _context.Executions.Update(Execution);
        }
    }
}
