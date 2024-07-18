using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class createAuthDbfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd9960df-9e7e-4a3d-8cd4-767bf0b2c0fb",
                column: "ConcurrencyStamp",
                value: "cd9960df-9e7e-4a3d-8cd4-767bf0b2c0fb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd86f795-addb-43d7-885d-eb966325005b",
                column: "ConcurrencyStamp",
                value: "dd86f795-addb-43d7-885d-eb966325005b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbea7556-ee0c-4116-a2ae-f1e377dc6779",
                column: "ConcurrencyStamp",
                value: "fbea7556-ee0c-4116-a2ae-f1e377dc6779");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7a9f82-1927-4ca6-81e3-64384b8a2037",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ba0da31-3ba3-49c8-8de4-ca74dfb15c9d", "AQAAAAIAAYagAAAAEOa+qKmIwF/uOGAgGLfzQ6YLNriZFCjPOQFWn50QfOFYuNTag0b3kidG2pQHbBP9Rw==", "22619821-b781-49e9-95a0-62d46b60be04" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd9960df-9e7e-4a3d-8cd4-767bf0b2c0fb",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd86f795-addb-43d7-885d-eb966325005b",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbea7556-ee0c-4116-a2ae-f1e377dc6779",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7a9f82-1927-4ca6-81e3-64384b8a2037",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9833d492-fe72-444e-a100-a88295db8207", "AQAAAAIAAYagAAAAELrv/px3ZvwifQ0kOQej65HcuVokxJ7T/LGRU3rmITeT0c1EVaeLpS4RjKjvyj6IaQ==", "93025dd1-3da4-4d61-adc0-42c36dea894e" });
        }
    }
}
