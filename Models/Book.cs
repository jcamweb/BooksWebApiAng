using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksWebApiAng.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string Titulo { get; set; }
       [Column(TypeName = "nvarchar(40)")]
        public string Autor { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string Editorial { get; set; }
    }
}
