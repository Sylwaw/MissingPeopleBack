using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MissingPeople.Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DictFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictFeatures", x => x.Id);
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
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SecondName = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    YearOfBirth = table.Column<int>(type: "integer", nullable: false),
                    DateOfDisappear = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictDetailFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DictFeatureId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictDetailFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictDetailFeatures_DictFeatures_DictFeatureId",
                        column: x => x.DictFeatureId,
                        principalTable: "DictFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ProvinceId = table.Column<int>(type: "integer", nullable: false),
                    ProvincesId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictCities_DictProvinces_ProvincesId",
                        column: x => x.ProvincesId,
                        principalTable: "DictProvinces",
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
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    DictFeatureId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_DictFeatures_DictFeatureId",
                        column: x => x.DictFeatureId,
                        principalTable: "DictFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Features_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeightFrom = table.Column<int>(type: "integer", nullable: false),
                    HeightTo = table.Column<int>(type: "integer", nullable: false),
                    WeightFrom = table.Column<int>(type: "integer", nullable: false),
                    WeightTo = table.Column<int>(type: "integer", nullable: false),
                    ClothesDetails = table.Column<string>(type: "text", nullable: true),
                    OtherDetails = table.Column<string>(type: "text", nullable: true),
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeopleDetails_People_PersonId",
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

            migrationBuilder.CreateTable(
                name: "LastLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_LastLocations_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DictDetailFeatureId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    FeatureID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailFeatures_DictDetailFeatures_DictDetailFeatureId",
                        column: x => x.DictDetailFeatureId,
                        principalTable: "DictDetailFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailFeatures_Features_FeatureID",
                        column: x => x.FeatureID,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangersOfLife_PersonId",
                table: "DangersOfLife",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailFeatures_DictDetailFeatureId",
                table: "DetailFeatures",
                column: "DictDetailFeatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailFeatures_FeatureID",
                table: "DetailFeatures",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_DictCities_ProvincesId",
                table: "DictCities",
                column: "ProvincesId");

            migrationBuilder.CreateIndex(
                name: "IX_DictDetailFeatures_DictFeatureId",
                table: "DictDetailFeatures",
                column: "DictFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_DictFeatureId",
                table: "Features",
                column: "DictFeatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_PersonId",
                table: "Features",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LastLocations_CityId",
                table: "LastLocations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_LastLocations_PersonId",
                table: "LastLocations",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeopleDetails_PersonId",
                table: "PeopleDetails",
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
                name: "DetailFeatures");

            migrationBuilder.DropTable(
                name: "LastLocations");

            migrationBuilder.DropTable(
                name: "PeopleDetails");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "DictDetailFeatures");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "DictCities");

            migrationBuilder.DropTable(
                name: "DictFeatures");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "DictProvinces");
        }
    }
}
