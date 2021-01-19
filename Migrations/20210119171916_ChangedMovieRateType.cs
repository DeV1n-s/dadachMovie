using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class ChangedMovieRateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "MoviesRating");

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "MoviesRating",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "MoviesRating");

            migrationBuilder.AddColumn<byte>(
                name: "Rating",
                table: "MoviesRating",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
