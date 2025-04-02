using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedLeaveAllocationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "LeaveAllocations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8603bdef-45d6-492d-9572-fcd6ba28b315",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e61a18e0-c4b1-4de8-bd77-4ba493f03286", "AQAAAAIAAYagAAAAEDcMKC36aI8YFmqToi+YhdGw7730GMEwrCw+fyg3iKhWo+5YjW9iv8MaC2TeJ+2Vjg==", "576323a7-d54d-49e8-af14-c3ff1c18392f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Days",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8603bdef-45d6-492d-9572-fcd6ba28b315",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c87dff84-9798-4278-abb8-1acbc62fa51c", "AQAAAAIAAYagAAAAEJMB/uvXTS9QtsZ5Kg2cz8VV+lqNFV8edssYLsBg2+RmsjaTpfaNJyO36dmU+K7wwA==", "b21c85b5-189b-497d-897a-23f3ad9317a7" });
        }
    }
}
