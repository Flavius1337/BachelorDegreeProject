using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazinAlbume.Migrations
{
    /// <inheritdoc />
    public partial class numeproducatorfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artisti_Albume_Albume_ArtistId",
                table: "Artisti_Albume");

            migrationBuilder.DropForeignKey(
                name: "FK_Artisti_Albume_Artisti_AlbumId",
                table: "Artisti_Albume");

            migrationBuilder.AddForeignKey(
                name: "FK_Artisti_Albume_Albume_AlbumId",
                table: "Artisti_Albume",
                column: "AlbumId",
                principalTable: "Albume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artisti_Albume_Artisti_ArtistId",
                table: "Artisti_Albume",
                column: "ArtistId",
                principalTable: "Artisti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artisti_Albume_Albume_AlbumId",
                table: "Artisti_Albume");

            migrationBuilder.DropForeignKey(
                name: "FK_Artisti_Albume_Artisti_ArtistId",
                table: "Artisti_Albume");

            migrationBuilder.AddForeignKey(
                name: "FK_Artisti_Albume_Albume_ArtistId",
                table: "Artisti_Albume",
                column: "ArtistId",
                principalTable: "Albume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artisti_Albume_Artisti_AlbumId",
                table: "Artisti_Albume",
                column: "AlbumId",
                principalTable: "Artisti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
