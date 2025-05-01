using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_AspNetUsers_UserId1",
                table: "TaskList");

            migrationBuilder.DropIndex(
                name: "IX_TaskList_UserId1",
                table: "TaskList");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17c96502-799f-4942-aba5-8e3d41d19c21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7473b9e-6b2b-4a05-b0df-534bc4820bcc");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TaskList");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TaskList",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a2b3c4d-0000-0000-0000-000000000001", null, "Admin", "ADMIN" },
                    { "1a2b3c4d-0000-0000-0000-000000000002", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_UserId",
                table: "TaskList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_AspNetUsers_UserId",
                table: "TaskList",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_AspNetUsers_UserId",
                table: "TaskList");

            migrationBuilder.DropIndex(
                name: "IX_TaskList_UserId",
                table: "TaskList");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0000-0000-0000-000000000001");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0000-0000-0000-000000000002");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TaskList",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "TaskList",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17c96502-799f-4942-aba5-8e3d41d19c21", null, "Admin", "ADMIN" },
                    { "f7473b9e-6b2b-4a05-b0df-534bc4820bcc", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_UserId1",
                table: "TaskList",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_AspNetUsers_UserId1",
                table: "TaskList",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
