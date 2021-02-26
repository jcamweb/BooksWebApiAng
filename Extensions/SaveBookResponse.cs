using BooksWebApiAng.Models;

namespace BooksWebApiAng.Extensions
{
    public class SaveBookResponse :BaseResponse
    {
        public Book Book { get; private set; }

        private SaveBookResponse(bool success, string message, Book book) : base(success, message)
        {
            Book = book;
        }


        public SaveBookResponse(Book book) : this(true, string.Empty, book)
        { }

        public SaveBookResponse(string message) : this(false, message, null)
        { }
    }
}
