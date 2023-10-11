using MagazinAlbume.Data.Base;
using MagazinAlbume.Models;

namespace MagazinAlbume.Data.Services
{
    public class ProducatoriService : EntityBaseRepository<Producator>, IProducatoriService
    {
        public ProducatoriService(AppDbContext context) : base(context)
        {
        }
    }
}