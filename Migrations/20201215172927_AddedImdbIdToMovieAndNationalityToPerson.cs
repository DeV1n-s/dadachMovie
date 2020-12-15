using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class AddedImdbIdToMovieAndNationalityToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImdbId",
                table: "Movies",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ImdbId",
                table: "Movies");
        }
    }
}
