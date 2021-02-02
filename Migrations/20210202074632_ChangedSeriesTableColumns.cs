using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class ChangedSeriesTableColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndYear",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "StartYear",
                table: "Series");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Series",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Series",
                type: "date",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Series");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Series",
                newName: "ReleaseDate");

            migrationBuilder.AddColumn<int>(
                name: "EndYear",
                table: "Series",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartYear",
                table: "Series",
                type: "int",
                nullable: true);
        }
    }
}
