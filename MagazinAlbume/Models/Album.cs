using MagazinAlbume.Data.Base;
using MagazinAlbume.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagazinAlbume.Models
{
    public class Album:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string NumeAlbum { get; set; }
        public string CopertaAlbum { get; set; }
        public double Pret { get; set; }
        public GenMuzical GenMuzical { get; set; }
        public TimeSpan DurataAlbum { get; set; }

        //Relatii
        public List<Artist_Album> Artisti_Albume { get; set; }

        //Producator
        public int ProducatorId { get; set; }
        [ForeignKey("ProducatorId")]
        public Producator Producator { get; set; }
    }

}    
