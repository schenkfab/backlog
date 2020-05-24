using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backlog.Migrations
{
    public partial class AddError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Errors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Errors_UserId",
                table: "Errors",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Errors");
        }
    }
}
