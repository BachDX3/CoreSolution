using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebMVC.Migrations
{
    /// <inheritdoc />
    public partial class EditUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("50e803ea-e960-40ec-a4fb-f326c4f933ad"), "3", "HR", "HR" },
                    { new Guid("b21774ae-8f3c-49ca-a67f-7f4034511a07"), "1", "Admin", "Admin" },
                    { new Guid("c0060b6a-2a8c-4c4f-8ea3-706a71e3345d"), "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("50e803ea-e960-40ec-a4fb-f326c4f933ad"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b21774ae-8f3c-49ca-a67f-7f4034511a07"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c0060b6a-2a8c-4c4f-8ea3-706a71e3345d"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

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
    }
}
