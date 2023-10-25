using OnlineBookStore.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace OnlineBookStore.Models
{
    public class Author: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name must be 3 and 50 chars" )]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        //Relationships
        public List<Book> Books { get; set; }
    }
}
