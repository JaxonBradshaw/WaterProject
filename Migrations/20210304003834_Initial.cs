using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WaterProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Program = table.Column<string>(type: "TEXT", nullable: true),
                    Impact = table.Column<int>(type: "INTEGER", nullable: false),
                    Phase = table.Column<string>(type: "TEXT", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Features = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
