using BooksWebApiAng.Models;
using System.Collections.Generic;

namespace BooksWebApiAng.Extensions
{
    public class SaveBookResponse :BaseResponse
    {
        public Book Book { get; private set; }
        public IEnumerable<Book> lBook { get; private set; }

        private SaveBookResponse(bool success, string message, Book book, IEnumerable<Book> lbook) : base(success, message)
        {
            Book = book;
            lBook = lbook;
        }


        public SaveBookResponse(Book book) : this(true, string.Empty, book, null)
        { }

        public SaveBookResponse(IEnumerable<Book> lbook) : this(true, string.Empty, null, lbook)
        { }

        public SaveBookResponse(string message) : this(false, message, null, null)
        { }
    }
}
