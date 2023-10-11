using MagazinAlbume.Data;
using MagazinAlbume.Data.Services;
using MagazinAlbume.Data.Static;
using MagazinAlbume.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagazinAlbume.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ArtistiController : Controller
    {
        private readonly IArtistiService _service;

        public ArtistiController(IArtistiService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Artisti/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("NumeArtist,ProfilePictureURL,Biografie")] Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return View(artist);
            }
            await _service.AddAsync(artist);
            return RedirectToAction(nameof(Index));

        }

        [AllowAnonymous]
        //Get: Artisti/Details
        public async Task<IActionResult> Details(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);

            if (artistDetails == null) return View("Empty");
            return View(artistDetails);
        }
        //Get: Artisti/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails == null) return View("NotFound");
            return View(artistDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeArtist,ProfilePictureURL,Biografie")] Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return View(artist);
            }
            await _service.UpdateAsync(id, artist);
            return RedirectToAction(nameof(Index));
        }

            //Get: Artisti/Delete
            public async Task<IActionResult> Delete(int id)
            {
                var artistDetails = await _service.GetByIdAsync(id);
                if (artistDetails == null) return View("NotFound");
                return View(artistDetails);
            }

            [HttpPost, ActionName("Delete")]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var artistDetails = await _service.GetByIdAsync(id);
                if (artistDetails == null) return View("NotFound");

                await _service.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }
     }

