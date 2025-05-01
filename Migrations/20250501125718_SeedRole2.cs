using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59c7d6d6-6686-4337-a664-10f23870e25c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc026f09-cbe4-4388-a680-102f7dd7b802");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "62755d03-f0d8-4209-b416-9dec4f4a2f6b", null, "Admin", "ADMIN" },
                    { "ebde3dd0-bc5f-4237-bec0-22489aaf96e7", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62755d03-f0d8-4209-b416-9dec4f4a2f6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebde3dd0-bc5f-4237-bec0-22489aaf96e7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59c7d6d6-6686-4337-a664-10f23870e25c", null, "User", "USER" },
                    { "cc026f09-cbe4-4388-a680-102f7dd7b802", null, "Admin", "ADMIN" }
                });
        }
    }
}
