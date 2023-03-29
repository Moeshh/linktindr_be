using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbcontext.Migrations
{
    /// <inheritdoc />
    public partial class RemovedMedewerkerFromPlaatsing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plaatsing_Medewerker_MedewerkerId",
                table: "Plaatsing");

            migrationBuilder.DropIndex(
                name: "IX_Plaatsing_MedewerkerId",
                table: "Plaatsing");

            migrationBuilder.DropColumn(
                name: "MedewerkerId",
                table: "Plaatsing");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedewerkerId",
                table: "Plaatsing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plaatsing_MedewerkerId",
                table: "Plaatsing",
                column: "MedewerkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plaatsing_Medewerker_MedewerkerId",
                table: "Plaatsing",
                column: "MedewerkerId",
                principalTable: "Medewerker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
