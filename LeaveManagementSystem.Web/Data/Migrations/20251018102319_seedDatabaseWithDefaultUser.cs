using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedDatabaseWithDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "167bfeee-7c2c-42b2-9892-75288de99daf", null, "Administrator", "ADMINISTRATOR" },
                    { "73697ef3-8b7e-40df-a508-a284d2164bfd", null, "Supervisor", "SUPERVISOR" },
                    { "cba8f906-e6f4-42d1-93fd-68d27cdfb718", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a9193084-ff28-4cb2-be55-f0310bad461c", 0, "f25e1e47-5caa-49c8-9d0b-00c5e58f9a99", "admin@localhos.com", true, false, null, "ADMIN@LOCALHOS.COM", "ADMIN@LOCALHOS.COM", "AQAAAAIAAYagAAAAEGSC4Y3ng0WIbS9CI1jb5g0FmBqM9UllRDA3T+1b2KLf5tWlD+uJpHYQ9X/w3W8s2A==", null, false, "f7896caf-95db-466a-9d0c-85ca70ac9d3f", false, "admin@localhos.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "167bfeee-7c2c-42b2-9892-75288de99daf", "a9193084-ff28-4cb2-be55-f0310bad461c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73697ef3-8b7e-40df-a508-a284d2164bfd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cba8f906-e6f4-42d1-93fd-68d27cdfb718");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "167bfeee-7c2c-42b2-9892-75288de99daf", "a9193084-ff28-4cb2-be55-f0310bad461c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "167bfeee-7c2c-42b2-9892-75288de99daf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9193084-ff28-4cb2-be55-f0310bad461c");
        }
    }
}
