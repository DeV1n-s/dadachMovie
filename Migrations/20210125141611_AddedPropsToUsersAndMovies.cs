using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class AddedPropsToUsersAndMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImdbRatesCount",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "MetacriticRate",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "BannerPicture",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "AspNetUsers",
                type: "date",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 25, 17, 46, 10, 814, DateTimeKind.Local).AddTicks(7092), new DateTime(2021, 1, 25, 17, 46, 10, 814, DateTimeKind.Local).AddTicks(7631) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImdbRatesCount",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MetacriticRate",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "BannerPicture",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 25, 16, 22, 43, 148, DateTimeKind.Local).AddTicks(85), new DateTime(2021, 1, 25, 16, 22, 43, 148, DateTimeKind.Local).AddTicks(604) });
        }
    }
}
