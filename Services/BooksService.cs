using BooksWebApiAng.DTO;
using BooksWebApiAng.Extensions;
using BooksWebApiAng.Models;
using BooksWebApiAng.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BooksWebApiAng.Services
{
    public class BooksService : IBooksService
    {

        private readonly IBooksRepository _booksrepository;
        private readonly ILogger<BooksService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public BooksService (IBooksRepository booksrepository, ILogger<BooksService> logger, IUnitOfWork unitOfWork)
        {
            _booksrepository = booksrepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<SaveBookResponse> DeleteBook(int id)
        {

            var existingbook = await _booksrepository.FindByIdAsync(id);

            if (existingbook == null)
                return new SaveBookResponse("Book no encontrado.");

            try
            {
                _booksrepository.Delete(existingbook);
                await _unitOfWork.CompleteAsync();

                return new SaveBookResponse(existingbook);
            }
            catch (Exception ex)
            {
                
                return new SaveBookResponse($"Error borrando book: {ex.Message}");
            }

        }

        public async Task<SaveBookResponse> GetBook(int id)
        {
            
                      
                var existingbook = await _booksrepository.FindByIdAsync(id);

                if (existingbook == null)
                    return new SaveBookResponse("Book no encontrado.");
                
               
                return new SaveBookResponse(await _booksrepository.GetByIdAsync(id));
            
                      
                        
        }

        public async Task<SaveBookResponse> GetBooks()
        {


            var existingbook = await _booksrepository.GetAllAsync();

            if (existingbook == null)
                return new SaveBookResponse("Sin Books en datos.");


            return new SaveBookResponse(await _booksrepository.GetAllAsync());

         

        }

        public async Task<SaveBookResponse> PostBook(Book book)
        {

            try
            {
                await _booksrepository.CreateAsync(book);
                await _unitOfWork.CompleteAsync();

                return new SaveBookResponse(book);
            }
            catch (Exception ex)
            {
                
                return new SaveBookResponse($"Error guardando book: {ex.Message}");
            }

           
           
        }

        public async Task<SaveBookResponse> PutBook(int id, BookUpdDto book)
        {

            var existingBook = await _booksrepository.FindByIdAsync(id);

            if (existingBook == null)
                return new SaveBookResponse("Book no encontrado.");

            existingBook.Autor = book.Autor;
            existingBook.Titulo = book.Titulo;
            existingBook.Editorial = book.Editorial;
            try
            {
                _booksrepository.Update(existingBook);
                await _unitOfWork.CompleteAsync();
                return new SaveBookResponse(existingBook);
            }

            catch (Exception ex)
            {
                
                return new SaveBookResponse($"Error actualizando book: {ex.Message}");
            }

                            
               
        }
               
    }
}
