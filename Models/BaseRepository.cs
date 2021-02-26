namespace BooksWebApiAng.Models
{
    public abstract class BaseRepository
    {
        protected readonly BookContext _context;

        public BaseRepository(BookContext context)
        {
            _context = context;
        }
    }
}
