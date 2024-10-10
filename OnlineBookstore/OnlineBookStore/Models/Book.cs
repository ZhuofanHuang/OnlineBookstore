using OnlineBookStore.Data.Base;
using OnlineBookStore.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace OnlineBookStore.Models
{
    public class Book : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public string PublishDate { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Rating")]
        public double Rating { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Cover")]
        public string ImageURL { get; set; }
        public BookCategory BookCategory { get; set; }

        //Relationships
        
        //Author
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        //Publisher
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
    }
}
