using BooksWebApiAng.DTO;
using BooksWebApiAng.Extensions;
using BooksWebApiAng.Models;
using System.Threading.Tasks;

namespace BooksWebApiAng.Services
{
    public interface IBooksService
    {
        Task<SaveBookResponse> GetBooks();
        Task<SaveBookResponse> GetBook(int id);
        Task<SaveBookResponse> PutBook(int id, BookUpdDto book);
        Task<SaveBookResponse> PostBook(Book book);
        Task<SaveBookResponse> DeleteBook(int id);
    }
}
