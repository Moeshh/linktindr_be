using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbcontext.Migrations
{
    /// <inheritdoc />
    public partial class test01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "opdrachtgever",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<int>(type: "INT(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opdrachtgever", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "talentmanager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<int>(type: "INT(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_talentmanager", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    usertype = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "vacatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Uitstroomrichting = table.Column<string>(type: "ENUM('DevOps', 'Informatie Analist', 'C# Programmeur', 'Java Programmeur')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Startdate = table.Column<DateTime>(type: "Datetime(6)", nullable: false),
                    Enddate = table.Column<DateTime>(type: "Datetime(6)", nullable: false),
                    OpdrachtgeverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vacatures_opdrachtgever_OpdrachtgeverId",
                        column: x => x.OpdrachtgeverId,
                        principalTable: "opdrachtgever",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medewerker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "Datetime(6)", nullable: false),
                    PostCode = table.Column<string>(type: "VARCHAR(6)", maxLength: 6, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HouseNumber = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<int>(type: "INT(10)", maxLength: 10, nullable: false),
                    Radius = table.Column<int>(type: "INT(3)", maxLength: 3, nullable: false),
                    Uitstroomrichting = table.Column<string>(type: "ENUM('DevOps', 'Informatie Analist', 'C# Programmeur', 'Java Programmeur')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Photo = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfileText = table.Column<string>(type: "TEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TalentManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medewerker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medewerker_talentmanager_TalentManagerId",
                        column: x => x.TalentManagerId,
                        principalTable: "talentmanager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sollicitatie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(type: "ENUM('Match', 'Sollicitatie', 'Bedenktijd', 'Accept', 'Decline')", nullable: false, defaultValue: "Match")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Medewerker_akkoord = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    Opdrachtgever_akkoord = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    MedewerkerId = table.Column<int>(type: "int", nullable: false),
                    VacatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sollicitatie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sollicitatie_medewerker_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalTable: "medewerker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sollicitatie_vacatures_VacatureId",
                        column: x => x.VacatureId,
                        principalTable: "vacatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "plaatsing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SollicitatieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plaatsing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_plaatsing_sollicitatie_SollicitatieId",
                        column: x => x.SollicitatieId,
                        principalTable: "sollicitatie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_medewerker_TalentManagerId",
                table: "medewerker",
                column: "TalentManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_plaatsing_SollicitatieId",
                table: "plaatsing",
                column: "SollicitatieId");

            migrationBuilder.CreateIndex(
                name: "IX_sollicitatie_MedewerkerId",
                table: "sollicitatie",
                column: "MedewerkerId");

            migrationBuilder.CreateIndex(
                name: "IX_sollicitatie_VacatureId",
                table: "sollicitatie",
                column: "VacatureId");

            migrationBuilder.CreateIndex(
                name: "IX_vacatures_OpdrachtgeverId",
                table: "vacatures",
                column: "OpdrachtgeverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plaatsing");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "sollicitatie");

            migrationBuilder.DropTable(
                name: "medewerker");

            migrationBuilder.DropTable(
                name: "vacatures");

            migrationBuilder.DropTable(
                name: "talentmanager");

            migrationBuilder.DropTable(
                name: "opdrachtgever");
        }
    }
}
