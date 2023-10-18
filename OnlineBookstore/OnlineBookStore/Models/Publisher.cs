using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace OnlineBookStore.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]

        public string FullName { get; set; }
        [Display(Name = "Description")]

        public string Bio { get; set; }

        //Relationships
        public List<Book> Books { get; set; }
    }
}
