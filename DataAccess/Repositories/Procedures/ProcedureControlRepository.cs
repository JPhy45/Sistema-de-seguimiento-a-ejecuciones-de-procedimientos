
using Contracts.Procedures;
using DataAccess.Contexts;
using DataAccess.Repositories.Common;
using Domain.Domain.Entities;

namespace DataAccess.Repositories.Procedures
{
    public class ProcedureControlRepository : RepositoryBase, IProcedureControlRepository
    {
        public ProcedureControlRepository(AplicationContext context) : base(context) { }
        public void Add(ProcedureControl bases)
        {
            _context.Base.Add(bases);
        }
        public void Delete(ProcedureControl bases)
        {
            _context.Base.Remove(bases);
        }
        public IEnumerable<T> GetAll<T>() where T : ProcedureControl
        {
            return _context.Set<T>().ToList();
        }
        public T? GetById<T> (Guid id) where T : ProcedureControl
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }
        public void Update(ProcedureControl bases)
        {
            _context.Base.Update(bases);
        }
    
    
    }
}
