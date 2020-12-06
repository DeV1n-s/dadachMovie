﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dadachAPI;

namespace dadachAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201206093105_AddedPeopleShortBio")]
    partial class AddedPeopleShortBio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("dadachAPI.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("dadachAPI.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("InTheaters")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LongPara")
                        .HasColumnType("TEXT");

                    b.Property<string>("Picture")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rate")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortPara")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("dadachAPI.Entities.MoviesActors", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Character")
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("MoviesActors");
                });

            modelBuilder.Entity("dadachAPI.Entities.MoviesDirectors", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("MoviesDirectors");
                });

            modelBuilder.Entity("dadachAPI.Entities.MoviesGenres", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GenreId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MoviesGenres");
                });

            modelBuilder.Entity("dadachAPI.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Biography")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<string>("Picture")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortBio")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("dadachAPI.Entities.MoviesActors", b =>
                {
                    b.HasOne("dadachAPI.Entities.Movie", "Movie")
                        .WithMany("Casters")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dadachAPI.Entities.Person", "Person")
                        .WithMany("Casters")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("dadachAPI.Entities.MoviesDirectors", b =>
                {
                    b.HasOne("dadachAPI.Entities.Movie", "Movie")
                        .WithMany("Directors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dadachAPI.Entities.Person", "Person")
                        .WithMany("Directors")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("dadachAPI.Entities.MoviesGenres", b =>
                {
                    b.HasOne("dadachAPI.Entities.Genre", "Genre")
                        .WithMany("Genres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dadachAPI.Entities.Movie", "Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("dadachAPI.Entities.Genre", b =>
                {
                    b.Navigation("Genres");
                });

            modelBuilder.Entity("dadachAPI.Entities.Movie", b =>
                {
                    b.Navigation("Casters");

                    b.Navigation("Directors");

                    b.Navigation("Genres");
                });

            modelBuilder.Entity("dadachAPI.Entities.Person", b =>
                {
                    b.Navigation("Casters");

                    b.Navigation("Directors");
                });
#pragma warning restore 612, 618
        }
    }
}
