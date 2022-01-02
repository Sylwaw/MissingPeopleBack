using Microsoft.EntityFrameworkCore.Migrations;

namespace MissingPeople.Infrastructure.Migrations
{
    public partial class finalTheLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastLocationPerson");

            migrationBuilder.AddColumn<int>(
                name: "LastLocationId",
                table: "People",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_LastLocationId",
                table: "People",
                column: "LastLocationId");

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
                name: "FK_People_LastLocations_LastLocationId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_LastLocationId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LastLocationId",
                table: "People");

            migrationBuilder.CreateTable(
                name: "LastLocationPerson",
                columns: table => new
                {
                    LastLocationsId = table.Column<int>(type: "integer", nullable: false),
                    PeopleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastLocationPerson", x => new { x.LastLocationsId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_LastLocationPerson_LastLocations_LastLocationsId",
                        column: x => x.LastLocationsId,
                        principalTable: "LastLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LastLocationPerson_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LastLocationPerson_PeopleId",
                table: "LastLocationPerson",
                column: "PeopleId");
        }
    }
}
