﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dadachMovie;

namespace dadachMovie.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("dadachMovie.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("dadachMovie.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImdbId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("InTheaters")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Picture")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("Rate")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("dadachMovie.Entities.MoviesCasts", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Character")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("MoviesCasts");
                });

            modelBuilder.Entity("dadachMovie.Entities.MoviesDirectors", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("MoviesDirectors");
                });

            modelBuilder.Entity("dadachMovie.Entities.MoviesGenres", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MoviesGenres");
                });

            modelBuilder.Entity("dadachMovie.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Biography")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsCast")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDirector")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120) CHARACTER SET utf8mb4");

                    b.Property<string>("Nationality")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Picture")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ShortBio")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("dadachMovie.Entities.MoviesCasts", b =>
                {
                    b.HasOne("dadachMovie.Entities.Movie", "Movie")
                        .WithMany("Casts")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dadachMovie.Entities.Person", "Person")
                        .WithMany("Casts")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("dadachMovie.Entities.MoviesDirectors", b =>
                {
                    b.HasOne("dadachMovie.Entities.Movie", "Movie")
                        .WithMany("Directors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dadachMovie.Entities.Person", "Person")
                        .WithMany("Directors")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("dadachMovie.Entities.MoviesGenres", b =>
                {
                    b.HasOne("dadachMovie.Entities.Genre", "Genre")
                        .WithMany("Genres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dadachMovie.Entities.Movie", "Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("dadachMovie.Entities.Genre", b =>
                {
                    b.Navigation("Genres");
                });

            modelBuilder.Entity("dadachMovie.Entities.Movie", b =>
                {
                    b.Navigation("Casts");

                    b.Navigation("Directors");

                    b.Navigation("Genres");
                });

            modelBuilder.Entity("dadachMovie.Entities.Person", b =>
                {
                    b.Navigation("Casts");

                    b.Navigation("Directors");
                });
#pragma warning restore 612, 618
        }
    }
}
