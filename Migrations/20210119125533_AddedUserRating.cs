using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class AddedUserRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Movies",
                newName: "ImdbRate");

            migrationBuilder.AddColumn<decimal>(
                name: "AverageRating",
                table: "Movies",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "MoviesRating",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesRating", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MoviesRating_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesRating_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviesRating_UserId",
                table: "MoviesRating",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviesRating");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "ImdbRate",
                table: "Movies",
                newName: "Rate");
        }
    }
}
