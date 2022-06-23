﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kolokwium_2_ko_s22454.Models;

namespace kolokwium_2_ko_s22454.Migrations
{
    [DbContext(typeof(MusicDbContext))]
    [Migration("20220623084754_start domowej bazy")]
    partial class startdomowejbazy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kolokwium_2_ko_s22454.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("kolokwium_2_ko_s22454.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("MusicLabel");
                });

            modelBuilder.Entity("kolokwium_2_ko_s22454.Models.Musican", b =>
                {
                    b.Property<int>("IdMusican")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusican");

                    b.ToTable("Musican");
                });

            modelBuilder.Entity("kolokwium_2_ko_s22454.Models.Musican_Track", b =>
                {
                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.HasKey("IdMusician", "IdTrack");

                    b.HasIndex("IdTrack");

                    b.ToTable("Musican_Track");
                });

            modelBuilder.Entity("kolokwium_2_ko_s22454.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duraturation")
                        .HasColumnType("real");

                    b.Property<int>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("kolokwium_2_ko_s22454.Models.Musican_Track", b =>
                {
                    b.HasOne("kolokwium_2_ko_s22454.Models.Musican", "Musican")
                        .WithMany("MusicanTracks")
                        .HasForeignKey("IdMusician")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kolokwium_2_ko_s22454.Models.Track", "Track")
                        .WithMany("MusicanTracks")
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musican");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("kolokwium_2_ko_s22454.Models.Musican", b =>
                {
                    b.Navigation("MusicanTracks");
                });

            modelBuilder.Entity("kolokwium_2_ko_s22454.Models.Track", b =>
                {
                    b.Navigation("MusicanTracks");
                });
#pragma warning restore 612, 618
        }
    }
}
