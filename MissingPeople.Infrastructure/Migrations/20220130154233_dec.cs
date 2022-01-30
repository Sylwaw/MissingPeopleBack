using Microsoft.EntityFrameworkCore.Migrations;

namespace MissingPeople.Infrastructure.Migrations
{
    public partial class dec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DecimalLatitude",
                table: "DictCities",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DecimalLongitude",
                table: "DictCities",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DecimalLatitude",
                table: "DictCities");

            migrationBuilder.DropColumn(
                name: "DecimalLongitude",
                table: "DictCities");
        }
    }
}
