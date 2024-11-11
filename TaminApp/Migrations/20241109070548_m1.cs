using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaminApp.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "housingTypes");

            migrationBuilder.DropTable(
                name: "insuranceTypes");

            migrationBuilder.DropTable(
                name: "sacrifices");

            migrationBuilder.DropColumn(
                name: "DiseaseTypeID",
                table: "peoples");

            migrationBuilder.DropColumn(
                name: "HousingTypeID",
                table: "peoples");

            migrationBuilder.DropColumn(
                name: "InsuranceTypeID",
                table: "peoples");

            migrationBuilder.RenameColumn(
                name: "marriageID",
                table: "peoples",
                newName: "InsuranceType");

            migrationBuilder.AddColumn<bool>(
                name: "HousingType",
                table: "peoples",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "marriage",
                table: "peoples",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PeopleDiseaseType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    DiseaseTypeId = table.Column<int>(type: "int", nullable: false),
                    DiseaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleDiseaseType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PeopleDiseaseType_diseaseTypes_DiseaseTypeId",
                        column: x => x.DiseaseTypeId,
                        principalTable: "diseaseTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleDiseaseType_peoples_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "peoples",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_peoples_BankID",
                table: "peoples",
                column: "BankID");

            migrationBuilder.CreateIndex(
                name: "IX_peoples_DegreeID",
                table: "peoples",
                column: "DegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleDiseaseType_DiseaseTypeId",
                table: "PeopleDiseaseType",
                column: "DiseaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleDiseaseType_PeopleId",
                table: "PeopleDiseaseType",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_peoples_banks_BankID",
                table: "peoples",
                column: "BankID",
                principalTable: "banks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_peoples_degrees_DegreeID",
                table: "peoples",
                column: "DegreeID",
                principalTable: "degrees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_peoples_banks_BankID",
                table: "peoples");

            migrationBuilder.DropForeignKey(
                name: "FK_peoples_degrees_DegreeID",
                table: "peoples");

            migrationBuilder.DropTable(
                name: "PeopleDiseaseType");

            migrationBuilder.DropIndex(
                name: "IX_peoples_BankID",
                table: "peoples");

            migrationBuilder.DropIndex(
                name: "IX_peoples_DegreeID",
                table: "peoples");

            migrationBuilder.DropColumn(
                name: "HousingType",
                table: "peoples");

            migrationBuilder.DropColumn(
                name: "marriage",
                table: "peoples");

            migrationBuilder.RenameColumn(
                name: "InsuranceType",
                table: "peoples",
                newName: "marriageID");

            migrationBuilder.AddColumn<int>(
                name: "DiseaseTypeID",
                table: "peoples",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HousingTypeID",
                table: "peoples",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsuranceTypeID",
                table: "peoples",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "housingTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HousingName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_housingTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "insuranceTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insuranceTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "sacrifices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SacrificeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SacrificePeriod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sacrifices", x => x.ID);
                });
        }
    }
}
