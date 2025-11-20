using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9193084-ff28-4cb2-be55-f0310bad461c",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "353cf43a-fd9a-4924-bccc-eac74084c01b", new DateOnly(1970, 1, 23), "Default", "Admin", "AQAAAAIAAYagAAAAEJKmx+2RbdOPSkmeFQLoWMwj7tI/aYe6RgKpw2UQU8FIFK+2cypzuMvkFLEmAQfqfg==", "f74c38c8-0210-4f2c-8158-f84e52a94628" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9193084-ff28-4cb2-be55-f0310bad461c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f25e1e47-5caa-49c8-9d0b-00c5e58f9a99", "AQAAAAIAAYagAAAAEGSC4Y3ng0WIbS9CI1jb5g0FmBqM9UllRDA3T+1b2KLf5tWlD+uJpHYQ9X/w3W8s2A==", "f7896caf-95db-466a-9d0c-85ca70ac9d3f" });
        }
    }
}
