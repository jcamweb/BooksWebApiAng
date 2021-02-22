using BooksWebApiAng.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksWebApiAng.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<Book> PutBook(int id, Book book);
        Task<Book> PostBook(Book book);
        Task<Book> DeleteBook(int id);
    }
}
