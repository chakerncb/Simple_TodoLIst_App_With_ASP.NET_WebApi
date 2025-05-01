using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "17c96502-799f-4942-aba5-8e3d41d19c21", null, "Admin", "ADMIN" },
                    { "f7473b9e-6b2b-4a05-b0df-534bc4820bcc", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17c96502-799f-4942-aba5-8e3d41d19c21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7473b9e-6b2b-4a05-b0df-534bc4820bcc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "62755d03-f0d8-4209-b416-9dec4f4a2f6b", null, "Admin", "ADMIN" },
                    { "ebde3dd0-bc5f-4237-bec0-22489aaf96e7", null, "User", "USER" }
                });
        }
    }
}
