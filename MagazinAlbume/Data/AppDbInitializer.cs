using MagazinAlbume.Data.Static;
using MagazinAlbume.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;

namespace MagazinAlbume.Data

{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)


        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();


                //Artist
                if (!context.Artisti.Any())
                {
                    context.Artisti.AddRange(new List<Artist>()
                    {
                        new Artist()
                        {
                           NumeArtist = "Michael Jackson",
                           ProfilePictureURL = "https://yt3.googleusercontent.com/drQOo1IcB7X_gA54Wdi4QHd1PBDbL3sD__6c_-PcFEccFzjeH0o4qYDdVvSa3GEuDFAQd95r1Q=s176-c-k-c0x00ffffff-no-rj",
                           Biografie = "Legenda muzicii pop"
                        }

                       
                     });
                    context.SaveChanges();
                }

                //Producator
                if (!context.Producatori.Any())
                {
                    context.Producatori.AddRange(new List<Producator>()
                    {
                        new Producator()
                        {
                           NumeProducator = "Quincy Jones",
                           ProfilePictureURL = "https://cdn.britannica.com/32/79832-050-BFF5EC8A/Quincy-Jones.jpg",
                           Biografie = ""
                        }
                     });
                    context.SaveChanges();
                }

                //Album



                if (!context.Albume.Any())
                {
                    context.Albume.AddRange(new List<Album>()
                    {
                        new Album()
                        {
                            NumeAlbum = "Thriller",
                            CopertaAlbum = "https://cdn.smehost.net/michaeljacksoncom-uslegacyprod/wp-content/uploads/2016/03/MJThriller25PRESSresize.jpg",
                            Pret = 29.50,
                            GenMuzical= Enum.GenMuzical.Pop,
                            DurataAlbum = TimeSpan.FromMinutes(42).Add(TimeSpan.FromSeconds(19)),
                            ProducatorId = 1


                }
            }); ;
                    context.SaveChanges();
                }
                //Artist & Album
                if (!context.Artisti_Albume.Any())
                {
                    context.Artisti_Albume.AddRange(new List<Artist_Album>()
                    {
                new Artist_Album()
                {
                    ArtistId = 1,
                    AlbumId = 7
                }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roluri
                var rolManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await rolManager.RoleExistsAsync(UserRoles.Admin))
                    await rolManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await rolManager.RoleExistsAsync(UserRoles.User))
                    await rolManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Useri
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "admin@magazinalbume.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        NumeUtilizator = "Admin",
                        UserName = "Admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@magazinalbume.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new User()
                    {
                        NumeUtilizator = "Utilizator aplicatie",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}


