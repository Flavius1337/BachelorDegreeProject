using MagazinAlbume.Data.Base;
using MagazinAlbume.Data.ViewModels;
using MagazinAlbume.Models;
using System.Threading.Tasks;

namespace MagazinAlbume.Data.Services
{
    public interface IAlbumeService:IEntityBaseRepository<Album>
    {
        Task<Album> GetAlbumByIdAsync(int id);
        Task<NewDropdownsVM> GetNewDropdownsValues();
        Task AddNewAlbumAsync(CreareAlbumVm data);
        Task UpdateAlbumAsync(CreareAlbumVm data);
    }
}
