using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Data;

namespace OnlineBookStore.Controllers
{
    public class PublishersController : Controller
    {
        private readonly AppDbContext _context;
        public PublishersController(AppDbContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
            var data = await _context.Publishers.ToListAsync();
            return View(data);
        }
    }
}
