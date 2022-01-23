using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MissingPeople.Infrastructure.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DictEyes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictEyes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictProvinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictProvinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictCities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<string>(type: "text", nullable: true),
                    Longitude = table.Column<string>(type: "text", nullable: true),
                    CordinateY = table.Column<double>(type: "double precision", nullable: false),
                    CordinateX = table.Column<double>(type: "double precision", nullable: false),
                    IdentifierTeryt = table.Column<int>(type: "integer", nullable: false),
                    ProvinceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictCities_DictProvinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "DictProvinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SecondName = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    YearOfBirth = table.Column<int>(type: "integer", nullable: false),
                    IsWaiting = table.Column<bool>(type: "boolean", nullable: false),
                    DateOfDisappear = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DictEyeID = table.Column<int>(type: "integer", nullable: true),
                    DictCityID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_DictCities_DictCityID",
                        column: x => x.DictCityID,
                        principalTable: "DictCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_People_DictEyes_DictEyeID",
                        column: x => x.DictEyeID,
                        principalTable: "DictEyes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DangersOfLife",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    IsAtRisk = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangersOfLife", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DangersOfLife_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeightFrom = table.Column<int>(type: "integer", nullable: true),
                    HeightTo = table.Column<int>(type: "integer", nullable: true),
                    WeightFrom = table.Column<int>(type: "integer", nullable: true),
                    WeightTo = table.Column<int>(type: "integer", nullable: true),
                    ClothesDescription = table.Column<string>(type: "text", nullable: true),
                    OtherDetails = table.Column<string>(type: "text", nullable: true),
                    TatoosDescription = table.Column<string>(type: "text", nullable: true),
                    ScarsDescription = table.Column<string>(type: "text", nullable: true),
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDetails_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangersOfLife_PersonId",
                table: "DangersOfLife",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DictCities_ProvinceId",
                table: "DictCities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_People_DictCityID",
                table: "People",
                column: "DictCityID");

            migrationBuilder.CreateIndex(
                name: "IX_People_DictEyeID",
                table: "People",
                column: "DictEyeID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetails_PersonId",
                table: "PersonDetails",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PersonId",
                table: "Pictures",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DangersOfLife");

            migrationBuilder.DropTable(
                name: "PersonDetails");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "DictCities");

            migrationBuilder.DropTable(
                name: "DictEyes");

            migrationBuilder.DropTable(
                name: "DictProvinces");
        }
    }
}
