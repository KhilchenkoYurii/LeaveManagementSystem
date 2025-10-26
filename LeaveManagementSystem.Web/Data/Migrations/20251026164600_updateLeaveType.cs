using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateLeaveType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9193084-ff28-4cb2-be55-f0310bad461c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "266987fb-02b8-4151-a641-23a00dc1c5e8", "AQAAAAIAAYagAAAAEG1RSR7JcAX+3ChbTw+hjK6TWIFNnxb3mVHg5kJn8KZwC34URB15mM4yvyj5AIn7Xg==", "73fcfd73-865e-4331-b48c-ebb15747e573" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9193084-ff28-4cb2-be55-f0310bad461c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9850e435-3bc5-4077-aec8-de7a2852ac88", "AQAAAAIAAYagAAAAEMHRXGGdL74b5Q/k9LSU4S1ANFp9BjTA61pU2f9atKktLbN1fdLcYhvKhOJgEOxS5Q==", "1a18fcba-bd74-4d75-8d8b-7d9b5c2eba1a" });
        }
    }
}
