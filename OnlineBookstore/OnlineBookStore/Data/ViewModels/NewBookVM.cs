using OnlineBookStore.Data.Base;
using OnlineBookStore.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace OnlineBookStore.Models
{
    public class NewBookVM
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage ="Book title is required")]
        public string Title { get; set; }
        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "Book ISBN is required")]
        public string ISBN { get; set; }
        [Display(Name = "Book Description")]
        [Required(ErrorMessage = "Book description is required")]
        public string Description { get; set; }
        [Display(Name = "Publish Year")]
        [Required(ErrorMessage = "Book publish year is required")]
        public string PublishDate { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Rating")]
        public double Rating { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Book price is required")]
        public double Price { get; set; }
        [Display(Name = "Cover URL")]
        [Required(ErrorMessage = "Book cover URL is required")]
        public string ImageURL { get; set; }
        [Display(Name = "Selet a category")]
        [Required(ErrorMessage = "Book category is required")]
        public BookCategory BookCategory { get; set; }
        [Display(Name = "Selet a author")]
        [Required(ErrorMessage = "Book author is required")]
        public int AuthorId { get; set; }
        [Display(Description = "Selet a publisher")]
        [Required(ErrorMessage = "Book publisher is required")]
        public int PublisherId { get; set; }
    }
}
