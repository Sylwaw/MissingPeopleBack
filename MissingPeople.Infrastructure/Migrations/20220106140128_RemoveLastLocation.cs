using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MissingPeople.Infrastructure.Migrations
{
    public partial class RemoveLastLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_LastLocations_LastLocationId",
                table: "People");

            migrationBuilder.DropTable(
                name: "LastLocations");

            migrationBuilder.DropIndex(
                name: "IX_People_LastLocationId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LastLocationId",
                table: "People");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastLocationId",
                table: "People",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LastLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LastLocations_DictCities_CityId",
                        column: x => x.CityId,
                        principalTable: "DictCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_LastLocationId",
                table: "People",
                column: "LastLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LastLocations_CityId",
                table: "LastLocations",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_LastLocations_LastLocationId",
                table: "People",
                column: "LastLocationId",
                principalTable: "LastLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
