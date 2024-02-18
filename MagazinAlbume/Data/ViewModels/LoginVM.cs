using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MagazinAlbume.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Adresa de email")]
        [Required(ErrorMessage = "Adresa de email este obligatorie!")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
