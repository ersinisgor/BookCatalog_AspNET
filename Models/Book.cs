using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Models
{
    public class Book
    {
        public int Id { get; set; } 
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Authro is required.")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Page count must be at least one.")]
        public int PageCount { get; set; }
    }
}
