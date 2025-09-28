using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomationEdariSamyaran.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DailyReminderTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyReminderTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPersonal = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reminderdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReminderHour = table.Column<TimeSpan>(type: "time", nullable: false),
                    Remindertext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Displayed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReminderTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReminderTasks_Personals_IdPersonal",
                        column: x => x.IdPersonal,
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyReminderTasks_IdPersonal",
                table: "DailyReminderTasks",
                column: "IdPersonal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyReminderTasks");
        }
    }
}
