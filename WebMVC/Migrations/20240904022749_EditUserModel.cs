using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebMVC.Migrations
{
    /// <inheritdoc />
    public partial class EditUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "FristName",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8bd9552d-8a87-4825-b711-38a02caa7e93"), "2", "User", "User" },
                    { new Guid("be1159ae-65ce-4b54-a080-dd496d3da30f"), "1", "Admin", "Admin" },
                    { new Guid("ca4861ab-457e-4529-b158-11d851580576"), "3", "HR", "HR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8bd9552d-8a87-4825-b711-38a02caa7e93"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("be1159ae-65ce-4b54-a080-dd496d3da30f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ca4861ab-457e-4529-b158-11d851580576"));

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "FristName");

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
    }
}
