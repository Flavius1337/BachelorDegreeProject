
using MagazinAlbume.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MagazinAlbume.Models
{
    public class Producator:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Numele Producatorului")]
   
        public string NumeProducator { get; set; }
        [Display(Name = "Poza de profil")]
      
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Biografia")]
        public string Biografie { get; set; }

        //Relatii 
        public List<Album>? Albume { get; set; }
    }
}
