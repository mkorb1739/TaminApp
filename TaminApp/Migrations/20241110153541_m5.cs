using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaminApp.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SacrificeID",
                table: "peoples",
                newName: "Sacrifice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sacrifice",
                table: "peoples",
                newName: "SacrificeID");
        }
    }
}
