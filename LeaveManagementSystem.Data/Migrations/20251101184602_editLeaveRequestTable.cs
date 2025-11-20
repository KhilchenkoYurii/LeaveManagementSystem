using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class editLeaveRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_LeaveRequestStatuses_LeaveRequestStatusId",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "LeaveRequestId",
                table: "LeaveRequests");

            migrationBuilder.AlterColumn<int>(
                name: "LeaveRequestStatusId",
                table: "LeaveRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9193084-ff28-4cb2-be55-f0310bad461c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a62f48df-289b-4666-a3bf-2205d0cb8ed0", "AQAAAAIAAYagAAAAEPxw9bFeQcyeGtXdiH0VdeQ610w9hIYHqxFzzGu36slSkxvwvrUW9+XBD4XZPkBN1A==", "b9f5dc39-2973-47dd-b4ca-74e38d3c5405" });

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_LeaveRequestStatuses_LeaveRequestStatusId",
                table: "LeaveRequests",
                column: "LeaveRequestStatusId",
                principalTable: "LeaveRequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_LeaveRequestStatuses_LeaveRequestStatusId",
                table: "LeaveRequests");

            migrationBuilder.AlterColumn<int>(
                name: "LeaveRequestStatusId",
                table: "LeaveRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LeaveRequestId",
                table: "LeaveRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9193084-ff28-4cb2-be55-f0310bad461c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d14537a4-b01e-40ee-816b-2fddb0998edc", "AQAAAAIAAYagAAAAEATiH1YBbG6KH9Niq7wczi2l+pc/erd4D+6yPG2SNbr2o12BrKwrlmrX3hQdZLuChw==", "041de0e3-c3d3-4894-8541-f5d9eac632a2" });

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_LeaveRequestStatuses_LeaveRequestStatusId",
                table: "LeaveRequests",
                column: "LeaveRequestStatusId",
                principalTable: "LeaveRequestStatuses",
                principalColumn: "Id");
        }
    }
}
