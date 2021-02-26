﻿using BooksWebApiAng.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksWebApiAng.Repositories
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        void PutBook(Book book);
        Task<Book> PostBook(Book book);
        Task<Book> DeleteBook(int id);
        bool BookExist(int i);
        Task<Book> FindByIdAsync(int id);
    }
}
