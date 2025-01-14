using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAllTablesSeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Password", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 14, 21, 36, 40, 414, DateTimeKind.Local).AddTicks(3190), "pritom@gmail.com", "123456", "Admin", new DateTime(2025, 1, 14, 21, 36, 40, 414, DateTimeKind.Local).AddTicks(3220), "Admin" },
                    { 2, new DateTime(2025, 1, 14, 21, 36, 40, 414, DateTimeKind.Local).AddTicks(3230), "Shormi@gmail.com", "123456", "User", new DateTime(2025, 1, 14, 21, 36, 40, 414, DateTimeKind.Local).AddTicks(3230), "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
