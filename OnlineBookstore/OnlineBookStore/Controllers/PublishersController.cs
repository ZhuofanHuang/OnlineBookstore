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
    public class PublishersController : Controller
    {
        private readonly IPublishersService _service;
        public PublishersController(IPublishersService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task <IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Publishers/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);

            if(publisherDetails == null) return View("NotFound");
            return View(publisherDetails);
        }

        //Get: Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,Bio")]Publisher publisher)
        {
            if(ModelState.IsValid) return View(publisher);

            await _service.AddAsync(publisher);
            return RedirectToAction(nameof(Index));
        }

        //Get: Publishers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if(publisherDetails == null) return View("NotFound");
            return View(publisherDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Bio")] Publisher publisher)
        {
            if (ModelState.IsValid) return View(publisher);
            await _service.UpdateAsync(id, publisher);
            return RedirectToAction(nameof(Index));
        }

        //Get: Publishers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("NotFound");
            return View(publisherDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
