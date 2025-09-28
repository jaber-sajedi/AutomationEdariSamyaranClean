using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomationEdariSamyaran.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Cellar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CellarKolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellarKolls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CellarMoeins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdKoll = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellarMoeins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CellarMoeins_CellarKolls_IdKoll",
                        column: x => x.IdKoll,
                        principalTable: "CellarKolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CellarTafzillis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdKoll = table.Column<int>(type: "int", nullable: false),
                    IdMoein = table.Column<int>(type: "int", nullable: false),
                    IdUnitsMeasurement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellarTafzillis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CellarTafzillis_CellarKolls_IdKoll",
                        column: x => x.IdKoll,
                        principalTable: "CellarKolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CellarTafzillis_CellarMoeins_IdMoein",
                        column: x => x.IdMoein,
                        principalTable: "CellarMoeins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CellarTafzillis_UnitsMeasurements_IdUnitsMeasurement",
                        column: x => x.IdUnitsMeasurement,
                        principalTable: "UnitsMeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CellarMoeins_IdKoll",
                table: "CellarMoeins",
                column: "IdKoll");

            migrationBuilder.CreateIndex(
                name: "IX_CellarTafzillis_IdKoll",
                table: "CellarTafzillis",
                column: "IdKoll");

            migrationBuilder.CreateIndex(
                name: "IX_CellarTafzillis_IdMoein",
                table: "CellarTafzillis",
                column: "IdMoein");

            migrationBuilder.CreateIndex(
                name: "IX_CellarTafzillis_IdUnitsMeasurement",
                table: "CellarTafzillis",
                column: "IdUnitsMeasurement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CellarTafzillis");

            migrationBuilder.DropTable(
                name: "CellarMoeins");

            migrationBuilder.DropTable(
                name: "CellarKolls");
        }
    }
}
