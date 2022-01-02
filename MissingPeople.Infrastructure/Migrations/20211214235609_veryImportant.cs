using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MissingPeople.Infrastructure.Migrations
{
    public partial class veryImportant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DictEyes_Features_FeatureId",
                table: "DictEyes");

            migrationBuilder.DropTable(
                name: "DetailFeatures");

            migrationBuilder.DropTable(
                name: "DictBodyShapes");

            migrationBuilder.DropTable(
                name: "DictHairs");

            migrationBuilder.DropTable(
                name: "DictDetailFeatures");

            migrationBuilder.DropTable(
                name: "DictFeatures");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropIndex(
                name: "IX_DictEyes_FeatureId",
                table: "DictEyes");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "DictEyes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "DictEyes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DictBodyShapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeatureId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictBodyShapes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictBodyShapes_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeatureId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictHairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeatureId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictHairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictHairs_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictDetailFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DictFeatureId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                name: "DetailFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DictDetailFeatureId = table.Column<int>(type: "integer", nullable: false),
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
                name: "IX_DictEyes_FeatureId",
                table: "DictEyes",
                column: "FeatureId");

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
                name: "IX_DictBodyShapes_FeatureId",
                table: "DictBodyShapes",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_DictDetailFeatures_DictFeatureId",
                table: "DictDetailFeatures",
                column: "DictFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_DictFeatures_FeatureId",
                table: "DictFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_DictHairs_FeatureId",
                table: "DictHairs",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_PersonId",
                table: "Features",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_DictEyes_Features_FeatureId",
                table: "DictEyes",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
