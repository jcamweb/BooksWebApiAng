using AutoMapper;
using BooksWebApiAng.DTO;
using BooksWebApiAng.Models;
using BooksWebApiAng.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksWebApiAng.Extensions;

namespace BooksWebApiAng.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        private readonly ILogger<BooksService> _logger;
        private readonly IMapper _mapper;


        public BooksController(IBooksService booksService, ILogger<BooksService> logger, IMapper mapper)
        {
            _booksService = booksService;
            _logger = logger;
            _mapper = mapper;

          
        }

       
        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            
            var data = await _booksService.GetBooks();
            var resources = _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(data);
            return Ok(resources);
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

            return Ok(book);
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookUpdDto book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


          //  var bookobj = _mapper.Map<BookDto, Book>(book);
            var result = await _booksService.PutBook(id, book);

            if (!result.Success)
                return BadRequest(result.Message);

            var lbook = _mapper.Map<Book, BookDto>(result.Book);
            _logger.LogError($"Book actualizado {result.Book.BookId}");
            return Ok(lbook);

          
            
            
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookDto book)
        {
            if (!ModelState.IsValid)
             return BadRequest(ModelState.GetErrorMessages()); 
                       
                var bookobj = _mapper.Map<BookDto,Book>(book);
                var result = await _booksService.PostBook(bookobj);
            if (!result.Success)
                return BadRequest(result.Message);
                var lbook = _mapper.Map<Book, BookDto>(result.Book);
            _logger.LogError($"Creado libro {lbook.BookId}");
                return CreatedAtAction("GetBook", new { id = lbook.BookId }, lbook);
            
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
