using System.ComponentModel.DataAnnotations;

namespace MagazinAlbume.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Album Album { get; set; }
        public int Cantitate { get; set; }


        public string ShoppingCartId { get; set; }
    }
}
