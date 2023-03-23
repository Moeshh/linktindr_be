using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbcontext.Migrations
{
    /// <inheritdoc />
    public partial class AddedSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Vacatures_OpdrachtgeverId",
                table: "Vacature",
                newName: "IX_Vacature_OpdrachtgeverId");

            migrationBuilder.AddColumn<int>(
                name: "MedewerkerId",
                table: "Medewerker",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vacature",
                table: "Vacature",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Language = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Level = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedewerkerId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Medewerker_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalTable: "Medewerker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerker_MedewerkerId",
                table: "Medewerker",
                column: "MedewerkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_MedewerkerId",
                table: "Skill",
                column: "MedewerkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SkillId",
                table: "Skill",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medewerker_Medewerker_MedewerkerId",
                table: "Medewerker",
                column: "MedewerkerId",
                principalTable: "Medewerker",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sollicitatie_Vacature_VacatureId",
                table: "Sollicitatie",
                column: "VacatureId",
                principalTable: "Vacature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacature_Opdrachtgever_OpdrachtgeverId",
                table: "Vacature",
                column: "OpdrachtgeverId",
                principalTable: "Opdrachtgever",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medewerker_Medewerker_MedewerkerId",
                table: "Medewerker");

            migrationBuilder.DropForeignKey(
                name: "FK_Sollicitatie_Vacature_VacatureId",
                table: "Sollicitatie");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacature_Opdrachtgever_OpdrachtgeverId",
                table: "Vacature");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Medewerker_MedewerkerId",
                table: "Medewerker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vacature",
                table: "Vacature");

            migrationBuilder.DropColumn(
                name: "MedewerkerId",
                table: "Medewerker");

            migrationBuilder.RenameTable(
                name: "Vacature",
                newName: "Vacatures");

            migrationBuilder.RenameIndex(
                name: "IX_Vacature_OpdrachtgeverId",
                table: "Vacatures",
                newName: "IX_Vacatures_OpdrachtgeverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vacatures",
                table: "Vacatures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sollicitatie_Vacatures_VacatureId",
                table: "Sollicitatie",
                column: "VacatureId",
                principalTable: "Vacatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacatures_Opdrachtgever_OpdrachtgeverId",
                table: "Vacatures",
                column: "OpdrachtgeverId",
                principalTable: "Opdrachtgever",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
