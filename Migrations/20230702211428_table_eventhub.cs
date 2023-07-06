using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class table_eventhub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_table",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    User_id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "event_table",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Event_id = table.Column<int>(type: "integer", nullable: false),
                    Owner_id = table.Column<int>(type: "integer", nullable: false),
                    Event_title = table.Column<string>(type: "text", nullable: false),
                    Event_photo = table.Column<string>(type: "text", nullable: false),
                    Event_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Event_price = table.Column<int>(type: "integer", nullable: false),
                    Link_to_buy = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_event_table_user_table_UserID",
                        column: x => x.UserID,
                        principalTable: "user_table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "confirmed-people_table",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    EventID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_confirmed-people_table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_confirmed-people_table_event_table_EventID",
                        column: x => x.EventID,
                        principalTable: "event_table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_confirmed-people_table_user_table_UserID",
                        column: x => x.UserID,
                        principalTable: "user_table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_confirmed-people_table_EventID",
                table: "confirmed-people_table",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_confirmed-people_table_UserID",
                table: "confirmed-people_table",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_event_table_UserID",
                table: "event_table",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "confirmed-people_table");

            migrationBuilder.DropTable(
                name: "event_table");

            migrationBuilder.DropTable(
                name: "user_table");
        }
    }
}
