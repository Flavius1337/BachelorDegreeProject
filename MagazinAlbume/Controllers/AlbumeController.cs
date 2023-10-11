using MagazinAlbume.Data;
using MagazinAlbume.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagazinAlbume.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using MagazinAlbume.Data.Static;

namespace MagazinAlbume.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class AlbumeController : Controller
    {
        private readonly IAlbumeService _service;

        public AlbumeController(IAlbumeService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allAlbums = await _service.GetAllAsync();
            return View(allAlbums);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allAlbums = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {

                var filteredResult = allAlbums.Where(n => n.NumeAlbum.ToLower().Contains(searchString.ToLower())).ToList();         
                return View("Index", filteredResult);
            }

            return View("Index", allAlbums);
        }

        [AllowAnonymous]

        //GET: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var albumDetails = await _service.GetAlbumByIdAsync(id);
            return View(albumDetails);
        }
        //GET: Albume/Create

        public async Task<IActionResult> Create()
        {
            var albumDropdownsData = await _service.GetNewDropdownsValues();
            ViewBag.Producatori = new SelectList(albumDropdownsData.Producatori, "Id", "NumeProducator");
            ViewBag.Artisti = new SelectList(albumDropdownsData.Artisti, "Id", "NumeArtist");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreareAlbumVm album)
        {
            if (!ModelState.IsValid)
            {
                var albumDropdownsData = await _service.GetNewDropdownsValues();
                ViewBag.Producatori = new SelectList(albumDropdownsData.Producatori, "Id", "NumeProducator");
                ViewBag.Artisti = new SelectList(albumDropdownsData.Artisti, "Id", "NumeArtist");

                return View(album);
            }

            await _service.AddNewAlbumAsync(album);
            return RedirectToAction(nameof(Index));

        }

            //GET: Movies/Edit/1
            public async Task<IActionResult> Edit(int id)
            {
                var albumDetails = await _service.GetAlbumByIdAsync(id);
                if (albumDetails == null) return View("NotFound");

                var response = new CreareAlbumVm()
                {
                    Id = albumDetails.Id,
                    NumeAlbum = albumDetails.NumeAlbum,
                    Pret = albumDetails.Pret,
                    CopertaAlbum = albumDetails.CopertaAlbum,
                    GenMuzical = albumDetails.GenMuzical,
                    ArtistIds = albumDetails.Artisti_Albume.Select(n => n.ArtistId).ToList(),
                };

                var albumDropdownsData = await _service.GetNewDropdownsValues();

                ViewBag.Producatori = new SelectList(albumDropdownsData.Producatori, "Id", "NumeProducator");
                ViewBag.Artisti = new SelectList(albumDropdownsData.Artisti, "Id", "NumeArtist");

                return View(response);
            }
        

            [HttpPost]
            public async Task<IActionResult> Edit(int id, CreareAlbumVm album)
            {
                if (id != album.Id) return View("NotFound");

                if (!ModelState.IsValid)
                {
                    var albumDropdownsData = await _service.GetNewDropdownsValues();

                    ViewBag.Producatori = new SelectList(albumDropdownsData.Producatori, "Id", "NumeProducator");
                    ViewBag.Artisti = new SelectList(albumDropdownsData.Artisti, "Id", "NumeArtist");

                    return View(album);
                }

                await _service.UpdateAlbumAsync(album);
                return RedirectToAction(nameof(Index));
            }
        }
    }
