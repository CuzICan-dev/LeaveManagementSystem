using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesandUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "270edc1f-8185-4d77-9484-04c3dafbadca", null, "Supervisor", "SUPERVISOR" },
                    { "4fdeb75e-cbdd-4cb3-871d-4d0cee998c67", null, "Employee", "EMPLOYEE" },
                    { "a83295f2-0168-44a4-8e78-ceeb026422bf", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8603bdef-45d6-492d-9572-fcd6ba28b315", 0, "6833954b-f786-4869-a2c4-41710998432b", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEAS7QuF16QIbY5u40114ME7WFfxZyNCx4WX/SYEWFAa5Wc8ADZfT4nW352IdGZo+BQ==", null, false, "4d866a93-01a0-478f-890c-a6a24d5f476d", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a83295f2-0168-44a4-8e78-ceeb026422bf", "8603bdef-45d6-492d-9572-fcd6ba28b315" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "270edc1f-8185-4d77-9484-04c3dafbadca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fdeb75e-cbdd-4cb3-871d-4d0cee998c67");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a83295f2-0168-44a4-8e78-ceeb026422bf", "8603bdef-45d6-492d-9572-fcd6ba28b315" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a83295f2-0168-44a4-8e78-ceeb026422bf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8603bdef-45d6-492d-9572-fcd6ba28b315");
        }
    }
}
