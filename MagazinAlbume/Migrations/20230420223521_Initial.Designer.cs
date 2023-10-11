﻿// <auto-generated />
using System;
using MagazinAlbume.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagazinAlbume.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230420223521_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagazinAlbume.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"));

                    b.Property<string>("CopertaAlbum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("DurataAlbum")
                        .HasColumnType("time");

                    b.Property<int>("GenMuzical")
                        .HasColumnType("int");

                    b.Property<string>("NumeAlbum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Pret")
                        .HasColumnType("float");

                    b.Property<int>("ProducatorId")
                        .HasColumnType("int");

                    b.HasKey("AlbumId");

                    b.HasIndex("ProducatorId");

                    b.ToTable("Albume");
                });

            modelBuilder.Entity("MagazinAlbume.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"));

                    b.Property<string>("Biografie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeArtist")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artisti");
                });

            modelBuilder.Entity("MagazinAlbume.Models.Artist_Album", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId", "AlbumId");

                    b.HasIndex("AlbumId");

                    b.ToTable("Artisti_Albume");
                });

            modelBuilder.Entity("MagazinAlbume.Models.Producator", b =>
                {
                    b.Property<int>("ProducatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProducatorId"));

                    b.Property<string>("Biografie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeProducator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProducatorId");

                    b.ToTable("Producatori");
                });

            modelBuilder.Entity("MagazinAlbume.Models.Album", b =>
                {
                    b.HasOne("MagazinAlbume.Models.Producator", "Producator")
                        .WithMany("Albume")
                        .HasForeignKey("ProducatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producator");
                });

            modelBuilder.Entity("MagazinAlbume.Models.Artist_Album", b =>
                {
                    b.HasOne("MagazinAlbume.Models.Artist", "Artist")
                        .WithMany("Artisti_Albume")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MagazinAlbume.Models.Album", "Album")
                        .WithMany("Artisti_Albume")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MagazinAlbume.Models.Album", b =>
                {
                    b.Navigation("Artisti_Albume");
                });

            modelBuilder.Entity("MagazinAlbume.Models.Artist", b =>
                {
                    b.Navigation("Artisti_Albume");
                });

            modelBuilder.Entity("MagazinAlbume.Models.Producator", b =>
                {
                    b.Navigation("Albume");
                });
#pragma warning restore 612, 618
        }
    }
}
