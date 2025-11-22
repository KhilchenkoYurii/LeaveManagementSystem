using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class createDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9193084-ff28-4cb2-be55-f0310bad461c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9da2c726-c40c-4257-a5de-4e0a7128292a", "AQAAAAIAAYagAAAAEO/7lqV22YnYIgOShzwb3LQ3Ik6Na+QCGcKi8xbQY/DPhIlE5z0rs+4NFb4O9dMLQw==", "49428294-366c-4022-bcb7-e23cc2c22c40" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9193084-ff28-4cb2-be55-f0310bad461c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a62f48df-289b-4666-a3bf-2205d0cb8ed0", "AQAAAAIAAYagAAAAEPxw9bFeQcyeGtXdiH0VdeQ610w9hIYHqxFzzGu36slSkxvwvrUW9+XBD4XZPkBN1A==", "b9f5dc39-2973-47dd-b4ca-74e38d3c5405" });
        }
    }
}
