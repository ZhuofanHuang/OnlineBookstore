using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookStore.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "FullName")]
        public string FullName { get; set; }
    }
}
