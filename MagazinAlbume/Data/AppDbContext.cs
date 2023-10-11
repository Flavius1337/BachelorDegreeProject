using MagazinAlbume.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagazinAlbume.Data
{
    public class AppDbContext :IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist_Album>().HasKey(arab => new
            {
                arab.ArtistId,
               arab.AlbumId
            });
            modelBuilder.Entity<Artist_Album>().HasOne(ab=> ab.Artist).WithMany(arab => arab.Artisti_Albume).HasForeignKey(ab => ab.ArtistId);
            modelBuilder.Entity<Artist_Album>().HasOne(ab => ab.Album).WithMany(arab => arab.Artisti_Albume).HasForeignKey(ab => ab.AlbumId);




            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Artist> Artisti { get; set; }
        public DbSet<Album> Albume { get; set; }
        public DbSet<Artist_Album> Artisti_Albume { get; set; }
        public DbSet<Producator> Producatori { get; set; }

        //Tabele legate de comanda
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
