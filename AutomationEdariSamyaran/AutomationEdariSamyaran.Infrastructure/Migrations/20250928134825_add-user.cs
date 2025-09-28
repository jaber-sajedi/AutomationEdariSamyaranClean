using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutomationEdariSamyaran.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArchivesKoll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivesKoll", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitsMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMeasurement = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsMeasurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPersonal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemporaryDeletion = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArchivesMoein",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdKoll = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivesMoein", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivesMoein_ArchivesKoll_IdKoll",
                        column: x => x.IdKoll,
                        principalTable: "ArchivesKoll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchivesTafzilli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTafzilly = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdKoll = table.Column<int>(type: "int", nullable: false),
                    IdMoein = table.Column<int>(type: "int", nullable: false),
                    TemporaryDeletion = table.Column<bool>(type: "bit", nullable: false),
                    AttachedFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivesTafzilli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivesTafzilli_ArchivesKoll_IdKoll",
                        column: x => x.IdKoll,
                        principalTable: "ArchivesKoll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArchivesTafzilli_ArchivesMoein_IdMoein",
                        column: x => x.IdMoein,
                        principalTable: "ArchivesMoein",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationSetting",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[,]
                {
                    { 1, "BackupPath", "C:\\Backup" },
                    { 2, "ApplicationName", "اتوماسیون اداری سامیاران" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivesMoein_IdKoll",
                table: "ArchivesMoein",
                column: "IdKoll");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivesTafzilli_IdKoll",
                table: "ArchivesTafzilli",
                column: "IdKoll");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivesTafzilli_IdMoein",
                table: "ArchivesTafzilli",
                column: "IdMoein");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationSetting");

            migrationBuilder.DropTable(
                name: "ArchivesTafzilli");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "UnitsMeasurements");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ArchivesMoein");

            migrationBuilder.DropTable(
                name: "ArchivesKoll");
        }
    }
}
