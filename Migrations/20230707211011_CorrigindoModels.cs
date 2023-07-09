using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_confirmed-people_table_event_table_EventID",
                table: "confirmed-people_table");

            migrationBuilder.DropForeignKey(
                name: "FK_confirmed-people_table_user_table_UserID",
                table: "confirmed-people_table");

            migrationBuilder.DropForeignKey(
                name: "FK_event_table_user_table_UserID",
                table: "event_table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_table",
                table: "user_table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_event_table",
                table: "event_table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_confirmed-people_table",
                table: "confirmed-people_table");

            migrationBuilder.RenameTable(
                name: "user_table",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "event_table",
                newName: "event");

            migrationBuilder.RenameTable(
                name: "confirmed-people_table",
                newName: "confirmed_people");

            migrationBuilder.RenameIndex(
                name: "IX_event_table_UserID",
                table: "event",
                newName: "IX_event_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_confirmed-people_table_UserID",
                table: "confirmed_people",
                newName: "IX_confirmed_people_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_confirmed-people_table_EventID",
                table: "confirmed_people",
                newName: "IX_confirmed_people_EventID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_event",
                table: "event",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_confirmed_people",
                table: "confirmed_people",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_confirmed_people_event_EventID",
                table: "confirmed_people",
                column: "EventID",
                principalTable: "event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_confirmed_people_user_UserID",
                table: "confirmed_people",
                column: "UserID",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_event_user_UserID",
                table: "event",
                column: "UserID",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_confirmed_people_event_EventID",
                table: "confirmed_people");

            migrationBuilder.DropForeignKey(
                name: "FK_confirmed_people_user_UserID",
                table: "confirmed_people");

            migrationBuilder.DropForeignKey(
                name: "FK_event_user_UserID",
                table: "event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_event",
                table: "event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_confirmed_people",
                table: "confirmed_people");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "user_table");

            migrationBuilder.RenameTable(
                name: "event",
                newName: "event_table");

            migrationBuilder.RenameTable(
                name: "confirmed_people",
                newName: "confirmed-people_table");

            migrationBuilder.RenameIndex(
                name: "IX_event_UserID",
                table: "event_table",
                newName: "IX_event_table_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_confirmed_people_UserID",
                table: "confirmed-people_table",
                newName: "IX_confirmed-people_table_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_confirmed_people_EventID",
                table: "confirmed-people_table",
                newName: "IX_confirmed-people_table_EventID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_table",
                table: "user_table",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_event_table",
                table: "event_table",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_confirmed-people_table",
                table: "confirmed-people_table",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_confirmed-people_table_event_table_EventID",
                table: "confirmed-people_table",
                column: "EventID",
                principalTable: "event_table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_confirmed-people_table_user_table_UserID",
                table: "confirmed-people_table",
                column: "UserID",
                principalTable: "user_table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_event_table_user_table_UserID",
                table: "event_table",
                column: "UserID",
                principalTable: "user_table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
