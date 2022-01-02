using Microsoft.EntityFrameworkCore.Migrations;

namespace MissingPeople.Infrastructure.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DictEyes_People_PersonID",
                table: "DictEyes");

            migrationBuilder.DropForeignKey(
                name: "FK_LastLocations_People_PersonId",
                table: "LastLocations");

            migrationBuilder.DropIndex(
                name: "IX_LastLocations_PersonId",
                table: "LastLocations");

            migrationBuilder.DropIndex(
                name: "IX_DictEyes_PersonID",
                table: "DictEyes");

            migrationBuilder.AddColumn<int>(
                name: "DictEyeId",
                table: "People",
                type: "integer",
                nullable: true);

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
                name: "IX_People_DictEyeId",
                table: "People",
                column: "DictEyeId");

            migrationBuilder.CreateIndex(
                name: "IX_LastLocationPerson_PeopleId",
                table: "LastLocationPerson",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_DictEyes_DictEyeId",
                table: "People",
                column: "DictEyeId",
                principalTable: "DictEyes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_DictEyes_DictEyeId",
                table: "People");

            migrationBuilder.DropTable(
                name: "LastLocationPerson");

            migrationBuilder.DropIndex(
                name: "IX_People_DictEyeId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DictEyeId",
                table: "People");

            migrationBuilder.CreateIndex(
                name: "IX_LastLocations_PersonId",
                table: "LastLocations",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DictEyes_PersonID",
                table: "DictEyes",
                column: "PersonID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DictEyes_People_PersonID",
                table: "DictEyes",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LastLocations_People_PersonId",
                table: "LastLocations",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
