using MagazinAlbume.Data.Base;
using MagazinAlbume.Data.ViewModels;
using MagazinAlbume.Models;
using Microsoft.EntityFrameworkCore;

namespace MagazinAlbume.Data.Services
{
    public class AlbumeService : EntityBaseRepository<Album>, IAlbumeService
    {
        private readonly AppDbContext _context;
        public AlbumeService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewAlbumAsync(CreareAlbumVm data)
        {
            var AlbumNou = new Album()
            {
                NumeAlbum = data.NumeAlbum,
                Pret = (double)data.Pret,
                CopertaAlbum = data.CopertaAlbum,
                GenMuzical = data.GenMuzical,
                DurataAlbum = data.DurataAlbum,
                ProducatorId = data.ProducatorId
            };
            await _context.Albume.AddAsync(AlbumNou);
            await _context.SaveChangesAsync();

            //Adaugam Artist_Albume
            foreach (var artistId in data.ArtistIds)
            {
                var newArtistAlbum = new Artist_Album()
                {
                    AlbumId = AlbumNou.Id,
                    ArtistId = artistId
                };
                await _context.Artisti_Albume.AddAsync(newArtistAlbum);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Album> GetAlbumByIdAsync(int id)
        {
            var albumDetails = await _context.Albume
                .Include(p => p.Producator)
                 .Include(am => am.Artisti_Albume).ThenInclude(a => a.Artist)
                .FirstOrDefaultAsync(n => n.Id == id);

            return albumDetails;
        }
        public async Task<NewDropdownsVM> GetNewDropdownsValues()
        {
            var response = new NewDropdownsVM()
            {
                Artisti = await _context.Artisti.OrderBy(n => n.NumeArtist).ToListAsync(),
                Producatori = await _context.Producatori.OrderBy(n => n.NumeProducator).ToListAsync()
            };

            return response;
        }

        public async Task UpdateAlbumAsync(CreareAlbumVm data)
        {
            var dbAlbum = await _context.Albume.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbAlbum != null)
            {
                {
                    dbAlbum.NumeAlbum = data.NumeAlbum;
                    dbAlbum.Pret = (double)data.Pret;
                    dbAlbum.CopertaAlbum = data.CopertaAlbum;
                    dbAlbum.GenMuzical = data.GenMuzical;
                    dbAlbum.DurataAlbum = data.DurataAlbum;
                    dbAlbum.ProducatorId = data.ProducatorId;
                    await _context.SaveChangesAsync();
                }

                //Stergere artisti existenti
                var ArtistiExistentiDb = _context.Artisti_Albume.Where(n => n.AlbumId == data.Id).ToList();
                _context.Artisti_Albume.RemoveRange(ArtistiExistentiDb);
                await _context.SaveChangesAsync();


                foreach (var artistId in data.ArtistIds)
                {
                    var newArtistAlbum = new Artist_Album()
                    {
                        AlbumId = data.Id,
                        ArtistId = artistId
                    };
                    await _context.Artisti_Albume.AddAsync(newArtistAlbum);
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}