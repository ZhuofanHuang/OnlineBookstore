using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Data.Base;
using OnlineBookStore.Models;

namespace OnlineBookStore.Data.Services
{
    public class AuthorsService : EntityBaseRepository<Author>, IAuthorsService
    {
        public AuthorsService(AppDbContext context) : base(context) { }
    }
}
