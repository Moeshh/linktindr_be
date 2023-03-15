using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbcontext.Migrations
{
    /// <inheritdoc />
    public partial class testest : Migration
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
                name: "sollicitatie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Medewerker_akkoord = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Opdrachtgever_akkoord = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sollicitatie", x => x.Id);
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
                    Enddate = table.Column<DateTime>(type: "Datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacatures", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medewerker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TalentManagerId = table.Column<int>(type: "int", nullable: false),
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
                        .Annotation("MySql:CharSet", "utf8mb4")
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

            migrationBuilder.CreateIndex(
                name: "IX_medewerker_TalentManagerId",
                table: "medewerker",
                column: "TalentManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medewerker");

            migrationBuilder.DropTable(
                name: "opdrachtgever");

            migrationBuilder.DropTable(
                name: "sollicitatie");

            migrationBuilder.DropTable(
                name: "vacatures");

            migrationBuilder.DropTable(
                name: "talentmanager");
        }
    }
}
