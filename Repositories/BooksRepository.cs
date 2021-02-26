using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksWebApiAng.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BooksWebApiAng.Repositories
{
    public class BooksRepository : BaseRepository, IBooksRepository
    {
        private readonly ILogger<BooksRepository> _logger;
        public BooksRepository(BookContext context, ILogger<BooksRepository> logger) : base(context)
        { _logger = logger; }

        public void DeleteBook(Book book)
        {

            _context.Books.Remove(book);

        }

        public async Task<Book> GetBook(int id)
        {
            Book book;
            try
            {
                book = await _context.Books.FindAsync(id);
                if (book != null) return book;
            }
            catch
            {
                book = null;

            }

            return book;

        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            List<Book> data;
            try
            {
                _logger.LogInformation("Recuperando libros de bbdd");
                data = await _context.Books.ToListAsync();
                _logger.LogInformation($"Recuperando {data.Count} libros");
                return (data);

            }

            catch (Exception Ex)

            {
                _logger.LogError($"Error recuperando libros: {Ex}");
                data = null;
                return (data);
            }
        }

        public async Task<Book> PostBook(Book book)
        {
           await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public void PutBook(Book book)
        {


            _context.Books.Update(book);
           


        }

        public async Task<Book> FindByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public bool BookExist(int id)
        {
            return  _context.Books.Any(e => e.BookId == id);
        }

    }
}
