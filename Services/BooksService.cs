using BooksWebApiAng.Extensions;
using BooksWebApiAng.Models;
using BooksWebApiAng.DTO;
using BooksWebApiAng.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksWebApiAng.Services
{
    public class BooksService : IBooksService
    {

        private readonly IBooksRepository _booksrepository;
        private readonly IUnitOfWork _unitOfWork;

        public BooksService (IBooksRepository booksrepository, IUnitOfWork unitOfWork)
        {
            _booksrepository = booksrepository;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<SaveBookResponse> DeleteBook(int id)
        {

            var existingbook = await _booksrepository.FindByIdAsync(id);

            if (existingbook == null)
                return new SaveBookResponse("Book no encontrado.");

            try
            {
                _booksrepository.DeleteBook(existingbook);
                await _unitOfWork.CompleteAsync();

                return new SaveBookResponse(existingbook);
            }
            catch (Exception ex)
            {
                
                return new SaveBookResponse($"Error boorando book: {ex.Message}");
            }

        }

        public async Task<Book> GetBook(int id)
        {
            

            return await _booksrepository.GetBook(id);
                        
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            

            return await _booksrepository.GetBooks();
        }

        public async Task<SaveBookResponse> PostBook(Book book)
        {

            try
            {
                await _booksrepository.PostBook(book);
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
                _booksrepository.PutBook(existingBook);
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
