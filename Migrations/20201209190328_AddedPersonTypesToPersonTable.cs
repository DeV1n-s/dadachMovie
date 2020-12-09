using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class AddedPersonTypesToPersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<float>(
                name: "Rate",
                table: "Movies",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "TEXT",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");
        }
    }
}
