using MagazinAlbume.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace MagazinAlbume.Data.ViewModels

   {
    public class CreareAlbumVm
    {
        public int Id { get; set; }

        [Display(Name = "Numele albumului:")]
        [Required(ErrorMessage = "Numele albumului este obligatoriu!")]
        public string NumeAlbum { get; set; }

        [Display(Name = "Pretul in lei:")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Pretul introdus este invalid!")]
        [Required(ErrorMessage = "Pretul este necesar!")]
        public double? Pret { get; set; }

        [Display(Name = "Coperta albumului:")]
        [Required(ErrorMessage = "Poza pentru coperta albumului este necesara!")]
        public string CopertaAlbum { get; set; }

        
        [Display(Name = "Selectaza o categorie muzicala")]
        [Required(ErrorMessage = "Categoria muzicala este necesara!")]
        public GenMuzical GenMuzical { get; set; }
        [Display(Name = "Durata albumului: (este necesara utilizarea formatului ore:minute:secunde ")]
        [Required(ErrorMessage = "Durata albumului este necesara!")]
        public TimeSpan DurataAlbum { get; set; }

        //Relatii
        [Display(Name = "Selecteaza artist-ul/artistii")]
        [Required(ErrorMessage = "Trebuie sa selectezi macar un artist!")]
        public List<int> ArtistIds { get; set; }


        [Display(Name = "Selecteaza un producator")]
        [Required(ErrorMessage = "Producatorul albumului este necesar!")]
        public int ProducatorId { get; set; }
    }
}