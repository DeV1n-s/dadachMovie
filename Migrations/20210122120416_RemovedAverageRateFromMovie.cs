using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class RemovedAverageRateFromMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AverageRating",
                table: "Movies",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
