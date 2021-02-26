using AutoMapper;
using BooksWebApiAng.DTO;
using BooksWebApiAng.Models;

namespace BooksWebApiAng.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>(); //Map from Book Object to BookDTO Object
            CreateMap<BookDto, Book>(); // Map from BookDto to Book object
        }
    }
}
