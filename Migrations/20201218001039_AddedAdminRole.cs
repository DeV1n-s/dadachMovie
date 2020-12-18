using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class AddedAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            INSERT INTO AspNetRoles (Id, Name, NormalizedName)
            values ('e70a6eb9-26db-4228-8959-b933b5ac5a41', 'Admin', 'Admin');
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            DELETE AspNetRoles WHERE id = 'e70a6eb9-26db-4228-8959-b933b5ac5a41';
            ");
        }
    }
}
