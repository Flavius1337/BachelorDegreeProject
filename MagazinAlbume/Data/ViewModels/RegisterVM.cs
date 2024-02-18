using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MagazinAlbume.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Numele tau")]
        [Required(ErrorMessage = "Numele este obligatoriu!")]
        public string NumeUtilizator { get; set; }

        [Display(Name = "Adresa de email")]
        [Required(ErrorMessage = "Adresa de email este obligatorie!")]
        public string EmailAddress { get; set; }

        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirma parola")]
        [Required(ErrorMessage = "Parola este obligatorie!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolele nu se potrivesc!")]
        public string ConfirmPassword { get; set; }
    }
}
