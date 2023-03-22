using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbcontext.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Opdrachtgever",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opdrachtgever", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TalentManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentManager", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vacatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Uitstroomrichting = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Startdate = table.Column<DateTime>(type: "Datetime(6)", nullable: false),
                    Enddate = table.Column<DateTime>(type: "Datetime(6)", nullable: false),
                    OpdrachtgeverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacatures_Opdrachtgever_OpdrachtgeverId",
                        column: x => x.OpdrachtgeverId,
                        principalTable: "Opdrachtgever",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medewerker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfBirth = table.Column<DateTime>(type: "Datetime(6)", nullable: false),
                    PostCode = table.Column<string>(type: "VARCHAR(6)", maxLength: 6, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HouseNumber = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Radius = table.Column<int>(type: "INT(3)", maxLength: 3, nullable: false),
                    Uitstroomrichting = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Photo = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfileText = table.Column<string>(type: "TEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TalentManagerId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medewerker_TalentManager_TalentManagerId",
                        column: x => x.TalentManagerId,
                        principalTable: "TalentManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sollicitatie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Medewerker_akkoord = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    Opdrachtgever_akkoord = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    MedewerkerId = table.Column<int>(type: "int", nullable: false),
                    VacatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sollicitatie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sollicitatie_Medewerker_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalTable: "Medewerker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sollicitatie_Vacatures_VacatureId",
                        column: x => x.VacatureId,
                        principalTable: "Vacatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Plaatsing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Started = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MedewerkerId = table.Column<int>(type: "int", nullable: false),
                    SollicitatieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plaatsing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plaatsing_Medewerker_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalTable: "Medewerker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plaatsing_Sollicitatie_SollicitatieId",
                        column: x => x.SollicitatieId,
                        principalTable: "Sollicitatie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerker_TalentManagerId",
                table: "Medewerker",
                column: "TalentManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Plaatsing_MedewerkerId",
                table: "Plaatsing",
                column: "MedewerkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Plaatsing_SollicitatieId",
                table: "Plaatsing",
                column: "SollicitatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Sollicitatie_MedewerkerId",
                table: "Sollicitatie",
                column: "MedewerkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sollicitatie_VacatureId",
                table: "Sollicitatie",
                column: "VacatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacatures_OpdrachtgeverId",
                table: "Vacatures",
                column: "OpdrachtgeverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plaatsing");

            migrationBuilder.DropTable(
                name: "Sollicitatie");

            migrationBuilder.DropTable(
                name: "Medewerker");

            migrationBuilder.DropTable(
                name: "Vacatures");

            migrationBuilder.DropTable(
                name: "TalentManager");

            migrationBuilder.DropTable(
                name: "Opdrachtgever");
        }
    }
}
