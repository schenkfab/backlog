using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backlog.Migrations
{
    public partial class RemoveBoard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardItems_Boards_BoardId",
                table: "BoardItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Feeds_FeedId",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "BoardSubscription");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_BoardItems_BoardId",
                table: "BoardItems");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "BoardItems");

            migrationBuilder.AlterColumn<long>(
                name: "FeedId",
                table: "Subscriptions",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SubscriptionId",
                table: "BoardItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItems_SubscriptionId",
                table: "BoardItems",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardItems_Subscriptions_SubscriptionId",
                table: "BoardItems",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Feeds_FeedId",
                table: "Subscriptions",
                column: "FeedId",
                principalTable: "Feeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardItems_Subscriptions_SubscriptionId",
                table: "BoardItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Feeds_FeedId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_BoardItems_SubscriptionId",
                table: "BoardItems");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "BoardItems");

            migrationBuilder.AlterColumn<long>(
                name: "FeedId",
                table: "Subscriptions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "BoardId",
                table: "BoardItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardSubscription",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardSubscription_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardSubscription_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardItems_BoardId",
                table: "BoardItems",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Boards_UserId",
                table: "Boards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardSubscription_BoardId",
                table: "BoardSubscription",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardSubscription_SubscriptionId",
                table: "BoardSubscription",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardItems_Boards_BoardId",
                table: "BoardItems",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Feeds_FeedId",
                table: "Subscriptions",
                column: "FeedId",
                principalTable: "Feeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
