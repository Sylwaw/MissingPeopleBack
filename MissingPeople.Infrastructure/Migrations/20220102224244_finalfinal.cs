using Microsoft.EntityFrameworkCore.Migrations;

namespace MissingPeople.Infrastructure.Migrations
{
    public partial class finalfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "LastLocations");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "DictEyes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "LastLocations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "DictEyes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
