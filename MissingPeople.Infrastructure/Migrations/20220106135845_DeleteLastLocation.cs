using Microsoft.EntityFrameworkCore.Migrations;

namespace MissingPeople.Infrastructure.Migrations
{
    public partial class DeleteLastLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_LastLocations_LastLocationID",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "LastLocationID",
                table: "People",
                newName: "LastLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_People_LastLocationID",
                table: "People",
                newName: "IX_People_LastLocationId");

            migrationBuilder.AddColumn<int>(
                name: "DictCityID",
                table: "People",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_DictCityID",
                table: "People",
                column: "DictCityID");

            migrationBuilder.AddForeignKey(
                name: "FK_People_DictCities_DictCityID",
                table: "People",
                column: "DictCityID",
                principalTable: "DictCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_LastLocations_LastLocationId",
                table: "People",
                column: "LastLocationId",
                principalTable: "LastLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_DictCities_DictCityID",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_LastLocations_LastLocationId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_DictCityID",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DictCityID",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "LastLocationId",
                table: "People",
                newName: "LastLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_People_LastLocationId",
                table: "People",
                newName: "IX_People_LastLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_People_LastLocations_LastLocationID",
                table: "People",
                column: "LastLocationID",
                principalTable: "LastLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
