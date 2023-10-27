using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OnlineBookStore.Data;
using OnlineBookStore.Data.Services;
using OnlineBookStore.Data.Static;
using OnlineBookStore.Models;

namespace OnlineBookStore.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class BooksController : Controller
    {
        
        private readonly IBooksService _service;
        public BooksController(IBooksService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(n => n.Author);
            return View(data);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(n => n.Author);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(n => n.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase) || n.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", data);
        }

        //Get: Books/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var bookDetail = await _service.GetBookByIdAsync(id);
            return View(bookDetail);
        }

        //Get: Books/Create
        public async Task<IActionResult> Create()
        {
            var bookDropdownsData = await _service.GetNewBookDropdownsValues();

            ViewBag.Author = new SelectList(bookDropdownsData.Authors, "Id", "FullName");
            ViewBag.Publisher = new SelectList(bookDropdownsData.Publishers, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM book) 
        { 
            if(!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownsValues();
                ViewBag.Author = new SelectList(bookDropdownsData.Authors, "Id", "FullName");
                ViewBag.Publisher = new SelectList(bookDropdownsData.Publishers, "Id", "FullName");
                return View(book);
            }

            await _service.AddNewBookAsync(book);
            return RedirectToAction(nameof(Index));
        }

        //Get: Books/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var bookDetails = await _service.GetBookByIdAsync(id);
            if(bookDetails == null) return View("NotFound");

            var response = new NewBookVM()
            {
                Id = bookDetails.Id,
                Title = bookDetails.Title,
                Description = bookDetails.Description,
                ISBN = bookDetails.ISBN,
                PublishDate = bookDetails.PublishDate,
                Quantity = bookDetails.Quantity,
                Rating = bookDetails.Rating,
                Price = bookDetails.Price,
                ImageURL = bookDetails.ImageURL,
                BookCategory = bookDetails.BookCategory,
                AuthorId = bookDetails.AuthorId,
                PublisherId = bookDetails.PublisherId
            };

            var bookDropdownsData = await _service.GetNewBookDropdownsValues();
            ViewBag.Author = new SelectList(bookDropdownsData.Authors, "Id", "FullName");
            ViewBag.Publisher = new SelectList(bookDropdownsData.Publishers, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM book)
        {
            if (id != book.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownsValues();
                ViewBag.Author = new SelectList(bookDropdownsData.Authors, "Id", "FullName");
                ViewBag.Publisher = new SelectList(bookDropdownsData.Publishers, "Id", "FullName");
                return View(book);
            }

            await _service.UpdateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }

    }
}
