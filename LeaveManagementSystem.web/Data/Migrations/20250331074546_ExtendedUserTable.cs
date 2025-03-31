using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.web.Data.Migrations
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
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8603bdef-45d6-492d-9572-fcd6ba28b315",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d927e3cd-5573-4507-a59b-0175ecdedcbc", new DateOnly(1992, 6, 21), "Default", "Admin", "AQAAAAIAAYagAAAAEDH27GHnxfc9NTukuqQ0u5YaGcw6gSfPjnPaqsEWOkc37FjgBcKbnbQVoxZk7eoTuQ==", "f3789bd9-cda6-4628-9888-0750832cc74e" });
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
                keyValue: "8603bdef-45d6-492d-9572-fcd6ba28b315",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6833954b-f786-4869-a2c4-41710998432b", "AQAAAAIAAYagAAAAEAS7QuF16QIbY5u40114ME7WFfxZyNCx4WX/SYEWFAa5Wc8ADZfT4nW352IdGZo+BQ==", "4d866a93-01a0-478f-890c-a6a24d5f476d" });
        }
    }
}
