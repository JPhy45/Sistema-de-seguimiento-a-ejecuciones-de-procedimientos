using DataAccess.Contexts;

namespace DataAccess.Repositories.Common
{
    public abstract class RepositoryBase
    {
        protected AplicationContext _context;

        protected RepositoryBase(AplicationContext context)
        {
            _context = context;
        }
    }
}
