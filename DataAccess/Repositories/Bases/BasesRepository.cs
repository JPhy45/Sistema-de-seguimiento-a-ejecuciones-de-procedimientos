
using Contracts.Bases;
using DataAccess.Contexts;
using DataAccess.Repositories.Common;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities;

namespace DataAccess.Repositories.Bases
{
    public class BasesRepository : RepositoryBase, IBaseRepository
    {
        public BasesRepository(AplicationContext context) : base(context) { }
        public void Add(Base bases)
        {
            _context.Phases.Add(bases);
        }
        public void Delete(Base bases)
        {
            _context.Phases.Remove(bases);
        }
        public IEnumerable<T> GetAll<T>() where T : Base
        {
            return _context.Set<T>().ToList();
        }
        public T? GetById<T> (Guid id) where T : Base
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }
        public void Update(Base bases)
        {
            _context.Phases.Update(bases);
        }
    
    
    }
}
