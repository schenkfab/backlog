using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backlog.Migrations
{
    public partial class LastCrawl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastCrawl",
                table: "Feeds",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastCrawl",
                table: "Feeds");
        }
    }
}
