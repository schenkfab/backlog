using Microsoft.EntityFrameworkCore.Migrations;

namespace backlog.Migrations
{
    public partial class FollowToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardItems_Collections_CollectionId",
                table: "BoardItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Users_UserId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_BoardItems_CollectionId",
                table: "BoardItems");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "BoardItems");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Collections",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FollowId",
                table: "BoardItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItems_FollowId",
                table: "BoardItems",
                column: "FollowId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardItems_Follows_FollowId",
                table: "BoardItems",
                column: "FollowId",
                principalTable: "Follows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardItems_Follows_FollowId",
                table: "BoardItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Users_UserId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_BoardItems_FollowId",
                table: "BoardItems");

            migrationBuilder.DropColumn(
                name: "FollowId",
                table: "BoardItems");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Collections",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "CollectionId",
                table: "BoardItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItems_CollectionId",
                table: "BoardItems",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardItems_Collections_CollectionId",
                table: "BoardItems",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
