using BooksWebApiAng.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksWebApiAng.Repositories
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        void Update(Book book);
        Task<Book> CreateAsync(Book book);
        void Delete(Book book);
        Task<Book> FindByIdAsync(int id);
    }
}
