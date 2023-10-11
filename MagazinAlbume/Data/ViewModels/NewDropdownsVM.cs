using MagazinAlbume.Models;

namespace MagazinAlbume.Data.ViewModels
{
    public class NewDropdownsVM
    {
        public NewDropdownsVM()
        {
            Producatori = new List<Producator>();
            Artisti = new List<Artist>();
        }

        public List<Producator> Producatori { get; set; } 
        public List<Artist> Artisti { get; set; }
    }
}