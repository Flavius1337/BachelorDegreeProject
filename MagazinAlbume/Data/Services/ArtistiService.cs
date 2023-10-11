using MagazinAlbume.Data.Base;
using MagazinAlbume.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinAlbume.Data.Services
{
    public class ArtistiService : EntityBaseRepository<Artist>, IArtistiService
    {
        private readonly AppDbContext _context;
        public ArtistiService(AppDbContext context) : base(context) { }
    
    }   
}
