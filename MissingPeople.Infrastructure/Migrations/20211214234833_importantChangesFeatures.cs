using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MissingPeople.Infrastructure.Migrations
{
    public partial class importantChangesFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_DictFeatures_DictFeatureId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_DictFeatureId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "DictFeatureId",
                table: "Features");

            migrationBuilder.RenameColumn(
                name: "ClothesDetails",
                table: "PeopleDetails",
                newName: "TatoosDescription");

            migrationBuilder.AddColumn<string>(
                name: "ClothesDescription",
                table: "PeopleDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScarsDescription",
                table: "PeopleDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "DictFeatures",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DictBodyShapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FeatureId = table.Column<int>(type: "integer", nullable: true)
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
                name: "DictEyes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PersonID = table.Column<int>(type: "integer", nullable: false),
                    FeatureId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictEyes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictEyes_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DictEyes_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DictHairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FeatureId = table.Column<int>(type: "integer", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_DictFeatures_FeatureId",
                table: "DictFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_DictBodyShapes_FeatureId",
                table: "DictBodyShapes",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_DictEyes_FeatureId",
                table: "DictEyes",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_DictEyes_PersonID",
                table: "DictEyes",
                column: "PersonID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DictHairs_FeatureId",
                table: "DictHairs",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_DictFeatures_Features_FeatureId",
                table: "DictFeatures",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DictFeatures_Features_FeatureId",
                table: "DictFeatures");

            migrationBuilder.DropTable(
                name: "DictBodyShapes");

            migrationBuilder.DropTable(
                name: "DictEyes");

            migrationBuilder.DropTable(
                name: "DictHairs");

            migrationBuilder.DropIndex(
                name: "IX_DictFeatures_FeatureId",
                table: "DictFeatures");

            migrationBuilder.DropColumn(
                name: "ClothesDescription",
                table: "PeopleDetails");

            migrationBuilder.DropColumn(
                name: "ScarsDescription",
                table: "PeopleDetails");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "DictFeatures");

            migrationBuilder.RenameColumn(
                name: "TatoosDescription",
                table: "PeopleDetails",
                newName: "ClothesDetails");

            migrationBuilder.AddColumn<int>(
                name: "DictFeatureId",
                table: "Features",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Features_DictFeatureId",
                table: "Features",
                column: "DictFeatureId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_DictFeatures_DictFeatureId",
                table: "Features",
                column: "DictFeatureId",
                principalTable: "DictFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
