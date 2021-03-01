using BooksWebApiAng.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksWebApiAng.Repositories
{
    public class BooksRepository : BaseRepository, IBooksRepository
    {
        private readonly ILogger<BooksRepository> _logger;
        public BooksRepository(BookContext context, ILogger<BooksRepository> logger) : base(context)
        { _logger = logger; }

        public void Delete(Book book)
        {
            try
            {
                _context.Books.Remove(book);
            }

            catch (Exception ex)
            {

                throw new Exception($"{nameof(book)} no ha podido eliminarse: {ex.Message}");
            }

        }

        public async Task<Book> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Books.FindAsync(id);
            }


            catch (Exception ex)
            {
                throw new Exception($"{nameof(GetByIdAsync)} no ha podido recuperar book: {ex.Message}");
            }

        }

        public async Task<IEnumerable<Book>> GetAllAsync()
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

        public async Task<Book> CreateAsync(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException($"{nameof(CreateAsync)} book no puede ser null");
            }

            try
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                return book;
            }

            catch (Exception ex)
            {
                throw new Exception($"{nameof(book)} no ha podido añadirse: {ex.Message}");
            }

        }

        public void Update(Book book)
        {

            if (book == null)
            {
                throw new ArgumentNullException($"{nameof(Update)} book null");
            }

            try
            {
                _context.Books.Update(book);
            }


            catch (Exception ex)
            {
                throw new Exception($"{nameof(book)} no ha podido actualizarse: {ex.Message}");

            }

            }

        public async Task<Book> FindByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

     }
}
