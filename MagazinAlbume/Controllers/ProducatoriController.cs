using MagazinAlbume.Data;
using MagazinAlbume.Data.Services;
using MagazinAlbume.Data.Static;
using MagazinAlbume.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MagazinAlbume.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducatoriController : Controller
    {
        private readonly IProducatoriService _service;



        public ProducatoriController(IProducatoriService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }
        [AllowAnonymous]
        //GET: producatori/detalii
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }
        //GET: producatori/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,NumeProducator,Biografie")] Producator producator)
        {
            if (!ModelState.IsValid) return View(producator);

            await _service.AddAsync(producator);
            return RedirectToAction(nameof(Index));
        }
        //GET: producatori/edit
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,NumeProducator,Biografie")] Producator producator)
        {
            if (!ModelState.IsValid) return View(producator);

            if (id == producator.Id)
            {
                await _service.UpdateAsync(id, producator);
                return RedirectToAction(nameof(Index));
            }
            return View(producator);
        }
        //GET: producatori/delete
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
