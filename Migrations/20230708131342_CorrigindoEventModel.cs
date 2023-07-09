using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoEventModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_event_user_UserID",
                table: "event");

            migrationBuilder.DropColumn(
                name: "Event_id",
                table: "event");

            migrationBuilder.DropColumn(
                name: "Owner_id",
                table: "event");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "event",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_event_UserID",
                table: "event",
                newName: "IX_event_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_event_user_OwnerId",
                table: "event",
                column: "OwnerId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_event_user_OwnerId",
                table: "event");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "event",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_event_OwnerId",
                table: "event",
                newName: "IX_event_UserID");

            migrationBuilder.AddColumn<int>(
                name: "Event_id",
                table: "event",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Owner_id",
                table: "event",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_event_user_UserID",
                table: "event",
                column: "UserID",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
