using Microsoft.EntityFrameworkCore.Migrations;

namespace MissingPeople.Infrastructure.Migrations
{
    public partial class AddForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DictCities_DictProvinces_ProvincesId",
                table: "DictCities");

            migrationBuilder.DropForeignKey(
                name: "FK_People_DictEyes_DictEyeId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_LastLocations_LastLocationId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_PeopleDetails_People_PersonId",
                table: "PeopleDetails");

            migrationBuilder.DropIndex(
                name: "IX_DictCities_ProvincesId",
                table: "DictCities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeopleDetails",
                table: "PeopleDetails");

            migrationBuilder.DropColumn(
                name: "ProvincesId",
                table: "DictCities");

            migrationBuilder.RenameTable(
                name: "PeopleDetails",
                newName: "PersonDetails");

            migrationBuilder.RenameColumn(
                name: "LastLocationId",
                table: "People",
                newName: "LastLocationID");

            migrationBuilder.RenameColumn(
                name: "DictEyeId",
                table: "People",
                newName: "DictEyeID");

            migrationBuilder.RenameIndex(
                name: "IX_People_LastLocationId",
                table: "People",
                newName: "IX_People_LastLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_People_DictEyeId",
                table: "People",
                newName: "IX_People_DictEyeID");

            migrationBuilder.RenameIndex(
                name: "IX_PeopleDetails_PersonId",
                table: "PersonDetails",
                newName: "IX_PersonDetails_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonDetails",
                table: "PersonDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DictCities_ProvinceId",
                table: "DictCities",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DictCities_DictProvinces_ProvinceId",
                table: "DictCities",
                column: "ProvinceId",
                principalTable: "DictProvinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_DictEyes_DictEyeID",
                table: "People",
                column: "DictEyeID",
                principalTable: "DictEyes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_LastLocations_LastLocationID",
                table: "People",
                column: "LastLocationID",
                principalTable: "LastLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDetails_People_PersonId",
                table: "PersonDetails",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DictCities_DictProvinces_ProvinceId",
                table: "DictCities");

            migrationBuilder.DropForeignKey(
                name: "FK_People_DictEyes_DictEyeID",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_LastLocations_LastLocationID",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonDetails_People_PersonId",
                table: "PersonDetails");

            migrationBuilder.DropIndex(
                name: "IX_DictCities_ProvinceId",
                table: "DictCities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonDetails",
                table: "PersonDetails");

            migrationBuilder.RenameTable(
                name: "PersonDetails",
                newName: "PeopleDetails");

            migrationBuilder.RenameColumn(
                name: "LastLocationID",
                table: "People",
                newName: "LastLocationId");

            migrationBuilder.RenameColumn(
                name: "DictEyeID",
                table: "People",
                newName: "DictEyeId");

            migrationBuilder.RenameIndex(
                name: "IX_People_LastLocationID",
                table: "People",
                newName: "IX_People_LastLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_People_DictEyeID",
                table: "People",
                newName: "IX_People_DictEyeId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonDetails_PersonId",
                table: "PeopleDetails",
                newName: "IX_PeopleDetails_PersonId");

            migrationBuilder.AddColumn<int>(
                name: "ProvincesId",
                table: "DictCities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeopleDetails",
                table: "PeopleDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DictCities_ProvincesId",
                table: "DictCities",
                column: "ProvincesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DictCities_DictProvinces_ProvincesId",
                table: "DictCities",
                column: "ProvincesId",
                principalTable: "DictProvinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_DictEyes_DictEyeId",
                table: "People",
                column: "DictEyeId",
                principalTable: "DictEyes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_LastLocations_LastLocationId",
                table: "People",
                column: "LastLocationId",
                principalTable: "LastLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleDetails_People_PersonId",
                table: "PeopleDetails",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
