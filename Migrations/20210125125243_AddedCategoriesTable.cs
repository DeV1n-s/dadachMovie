using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class AddedCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPerson_Category_CategoryId",
                table: "CategoryPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 25, 16, 22, 43, 148, DateTimeKind.Local).AddTicks(85), new DateTime(2021, 1, 25, 16, 22, 43, 148, DateTimeKind.Local).AddTicks(604) });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPerson_Categories_CategoryId",
                table: "CategoryPerson",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPerson_Categories_CategoryId",
                table: "CategoryPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 25, 2, 23, 11, 345, DateTimeKind.Local).AddTicks(8), new DateTime(2021, 1, 25, 2, 23, 11, 345, DateTimeKind.Local).AddTicks(533) });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPerson_Category_CategoryId",
                table: "CategoryPerson",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
