using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazinAlbume.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artisti",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeArtist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biografie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artisti", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Producatori",
                columns: table => new
                {
                    ProducatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProducator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biografie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producatori", x => x.ProducatorId);
                });

            migrationBuilder.CreateTable(
                name: "Albume",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeAlbum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CopertaAlbum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<double>(type: "float", nullable: false),
                    GenMuzical = table.Column<int>(type: "int", nullable: false),
                    DurataAlbum = table.Column<TimeSpan>(type: "time", nullable: false),
                    ProducatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albume", x => x.AlbumId);
                    table.ForeignKey(
                        name: "FK_Albume_Producatori_ProducatorId",
                        column: x => x.ProducatorId,
                        principalTable: "Producatori",
                        principalColumn: "ProducatorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artisti_Albume",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artisti_Albume", x => new { x.ArtistId, x.AlbumId });
                    table.ForeignKey(
                        name: "FK_Artisti_Albume_Albume_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Albume",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artisti_Albume_Artisti_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Artisti",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albume_ProducatorId",
                table: "Albume",
                column: "ProducatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Artisti_Albume_AlbumId",
                table: "Artisti_Albume",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artisti_Albume");

            migrationBuilder.DropTable(
                name: "Albume");

            migrationBuilder.DropTable(
                name: "Artisti");

            migrationBuilder.DropTable(
                name: "Producatori");
        }
    }
}
