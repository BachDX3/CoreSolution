using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("23ac87a9-2d09-45b6-b0ce-0712e63fb87d"), "3", "HR", "HR" },
                    { new Guid("2d72876d-c327-4674-9db2-a43e69e57acd"), "1", "Admin", "Admin" },
                    { new Guid("8bb9d1c0-78d8-4c6f-810a-345a8fdaa21a"), "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23ac87a9-2d09-45b6-b0ce-0712e63fb87d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2d72876d-c327-4674-9db2-a43e69e57acd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8bb9d1c0-78d8-4c6f-810a-345a8fdaa21a"));
        }
    }
}
