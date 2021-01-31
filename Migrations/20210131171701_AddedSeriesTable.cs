using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class AddedSeriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(300) CHARACTER SET utf8mb4", maxLength: 300, nullable: false),
                    ShortDescription = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: true),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    Seasons = table.Column<int>(type: "int", nullable: true),
                    Episodes = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ImdbRate = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ImdbRatesCount = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    MetacriticRate = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Lenght = table.Column<int>(type: "int", nullable: true),
                    ImdbId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Picture = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    BannerImage = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountrySerie",
                columns: table => new
                {
                    CountriesId = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountrySerie", x => new { x.CountriesId, x.SeriesId });
                    table.ForeignKey(
                        name: "FK_CountrySerie_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountrySerie_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreSerie",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSerie", x => new { x.GenresId, x.SeriesId });
                    table.ForeignKey(
                        name: "FK_GenreSerie_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSerie_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonSerie",
                columns: table => new
                {
                    DirectorsId = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSerie", x => new { x.DirectorsId, x.SeriesId });
                    table.ForeignKey(
                        name: "FK_PersonSerie_People_DirectorsId",
                        column: x => x.DirectorsId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonSerie_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesCasts",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SerieId = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesCasts", x => new { x.SerieId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_SeriesCasts_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesCasts_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesRatings",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SerieId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesRatings", x => new { x.SerieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_SeriesRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesRatings_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SerieUser",
                columns: table => new
                {
                    FavoriteSeriesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieUser", x => new { x.FavoriteSeriesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_SerieUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SerieUser_Series_FavoriteSeriesId",
                        column: x => x.FavoriteSeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SerieId",
                table: "Comments",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_CountrySerie_SeriesId",
                table: "CountrySerie",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreSerie_SeriesId",
                table: "GenreSerie",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSerie_SeriesId",
                table: "PersonSerie",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_ImdbId",
                table: "Series",
                column: "ImdbId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeriesCasts_PersonId",
                table: "SeriesCasts",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesRatings_UserId",
                table: "SeriesRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SerieUser_UsersId",
                table: "SerieUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Series_SerieId",
                table: "Comments",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Series_SerieId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "CountrySerie");

            migrationBuilder.DropTable(
                name: "GenreSerie");

            migrationBuilder.DropTable(
                name: "PersonSerie");

            migrationBuilder.DropTable(
                name: "SeriesCasts");

            migrationBuilder.DropTable(
                name: "SeriesRatings");

            migrationBuilder.DropTable(
                name: "SerieUser");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SerieId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
