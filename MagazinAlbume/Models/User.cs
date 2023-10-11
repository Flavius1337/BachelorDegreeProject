using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MagazinAlbume.Models
{
    public class User : IdentityUser
    {
        [Display(Name = "Numele utilizatorului")]
        public string NumeUtilizator { get; set; }
    }
}
