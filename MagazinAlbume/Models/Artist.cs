using MagazinAlbume.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MagazinAlbume.Models
{
    public class Artist : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Numele Artistului")]
        [Required(ErrorMessage = "Numele artistului este obligatoriu!")]
        public string NumeArtist { get; set; }
        [Display(Name ="Poza de profil")]
        [Required(ErrorMessage ="Poza de profil este obligatorie!")]
        public string ProfilePictureURL { get; set; }
        [Display(Name ="Biografia")]
        public string Biografie { get; set; }

        //Relatii
        public List<Artist_Album>? Artisti_Albume { get; set; }
    }
}
