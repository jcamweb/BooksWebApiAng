using BooksWebApiAng.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApiAng.Services
{
    public class BooksService : IBooksService
    {

        private readonly BookContext _context;
        private readonly ILogger<BooksService> _logger;

        public BooksService (BookContext context, ILogger<BooksService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Book> DeleteBook(int id)
        {
            Book book;
            try
            {
                 book = await _context.Books.FindAsync(id);
                if (book != null)
                {
                    _context.Books.Remove(book);
                    await _context.SaveChangesAsync();
                }

            }
            catch(Exception Ex)
            {
                 book = null;
                _logger.LogError($"Error borrande libro: {Ex}");
            }
            
            return book;
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
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> PutBook(int id, Book book)
        {
            
            if (id != book.BookId)
            {
                book = null;
                return book;
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    book = null;
                    return book;
                }
                else
                {
                    throw;
                }
            }

            return book;
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }

               
    }
}
