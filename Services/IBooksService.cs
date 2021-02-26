using BooksWebApiAng.Models;
using BooksWebApiAng.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksWebApiAng.Extensions;

namespace BooksWebApiAng.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<SaveBookResponse> PutBook(int id, BookUpdDto book);
        Task<SaveBookResponse> PostBook(Book book);
        Task<Book> DeleteBook(int id);
    }
}
