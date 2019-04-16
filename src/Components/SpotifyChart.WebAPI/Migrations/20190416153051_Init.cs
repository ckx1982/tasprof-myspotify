using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpotifyChart.WebAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpotifyCharts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpotifyCharts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpotifyChartItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChartId = table.Column<int>(nullable: false),
                    Artist = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpotifyChartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpotifyChartItems_SpotifyCharts_ChartId",
                        column: x => x.ChartId,
                        principalTable: "SpotifyCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpotifyChartItems_ChartId",
                table: "SpotifyChartItems",
                column: "ChartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpotifyChartItems");

            migrationBuilder.DropTable(
                name: "SpotifyCharts");
        }
    }
}
