using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCatalog.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50,ErrorMessage ="{0} must be max {1} characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Authro is required.")]
        [StringLength(50, ErrorMessage = "{0} must be max {1} characters.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(50, ErrorMessage = "{0} must be max {1} characters.")]
        public string Genre { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} must be at least {1}.")]
        [DisplayName("Page Count")]
        public int PageCount { get; set; }
    }
}
