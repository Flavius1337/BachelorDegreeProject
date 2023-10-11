using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagazinAlbume.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; } 
        public int Cantitate { get; set; }
        public double Pret { get; set; }

        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public Album Album { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
