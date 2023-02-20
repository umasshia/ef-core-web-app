using System.ComponentModel.DataAnnotations;

namespace ef_core_web_app.Models{ 
    public class Book{
        public int BookId { get; set; }
        [StringLength(255)]
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}