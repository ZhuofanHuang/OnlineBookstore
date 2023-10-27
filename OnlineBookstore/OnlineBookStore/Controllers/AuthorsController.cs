using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Data;
using OnlineBookStore.Data.Services;
using OnlineBookStore.Data.Static;
using OnlineBookStore.Models;

namespace OnlineBookStore.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class AuthorsController : Controller
    {
        private readonly IAuthorsService _service;
        public AuthorsController(IAuthorsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Authors/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);

            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,Bio")]Author author)
        {
            if (ModelState.IsValid) return View(author);
   
            await _service.AddAsync(author);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);
            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Bio")] Author author)
        {
            if (ModelState.IsValid) return View(author);
            await _service.UpdateAsync(id,author);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);
            if (authorDetails == null) return View("NotFound");
            return View(authorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
