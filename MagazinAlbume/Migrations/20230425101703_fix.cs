using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazinAlbume.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Artisti",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Albume",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Artisti",
                newName: "ArtistId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Albume",
                newName: "AlbumId");
        }
    }
}
