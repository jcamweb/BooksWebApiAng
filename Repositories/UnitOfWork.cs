using BooksWebApiAng.Models;
using System.Threading.Tasks;

namespace BooksWebApiAng.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookContext _context;

        public UnitOfWork(BookContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
