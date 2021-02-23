using BooksWebApiAng.Models;
using BooksWebApiAng.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksWebApiAng.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        private readonly ILogger<BooksService> _logger;
        
        public BooksController(IBooksService booksService, ILogger<BooksService> logger)
        {
            _booksService = booksService;
            _logger = logger;

          
        }

       
        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            
            var data = await _booksService.GetBooks();
            return Ok(data);
        }




        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _booksService.GetBook(id);

            if (book == null)
            {
                _logger.LogError($"Error recuperando libro {book.BookId}");
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
                else
            {
                var lbook = await _booksService.PutBook(id, book);

                if (lbook == null)
                {
                    _logger.LogError($"Error actualizando libro {book.BookId}");
                    return NotFound();
                }

                return Ok(lbook);
            }
            
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            else
            {
                var lbook = await _booksService.PostBook(book);
                _logger.LogError($"Creado libro {book.BookId}");
                return CreatedAtAction("GetBook", new { id = lbook.BookId }, lbook);
            }
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            
            var book = await _booksService.DeleteBook(id);
            if (book == null)
            {
                _logger.LogError($"Error borrando libro {book.BookId}");
                return NotFound();
            }

           

            return NoContent();
        }

       
    }
}
