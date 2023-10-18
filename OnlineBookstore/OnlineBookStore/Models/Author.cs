using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace OnlineBookStore.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        //public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //Relationships
        public List<Book> Books{ get; set; }
    }
}
