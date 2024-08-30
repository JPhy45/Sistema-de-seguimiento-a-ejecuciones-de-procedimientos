using Contracts;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AplicationContext _context;

        public UnitOfWork(AplicationContext context)
        {
            _context = context;
            if (!context.Database.CanConnect())
            { context.Database.Migrate(); }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
