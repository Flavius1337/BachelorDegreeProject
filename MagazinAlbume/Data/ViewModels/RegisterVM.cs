using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MagazinAlbume.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Numele este obligatoriu!")]
        public string NumeUtilizator { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Adresa de email este obligatorie!")]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Parola este obligatorie!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolele nu se potrivesc!")]
        public string ConfirmPassword { get; set; }
    }
}
