using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class DatabaseUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd9960df-9e7e-4a3d-8cd4-767bf0b2c0fb",
                column: "NormalizedName",
                value: "SUPERADMIN");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd86f795-addb-43d7-885d-eb966325005b",
                column: "NormalizedName",
                value: "USER");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbea7556-ee0c-4116-a2ae-f1e377dc6779",
                column: "NormalizedName",
                value: "ADMIN");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7a9f82-1927-4ca6-81e3-64384b8a2037",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a265db35-53f2-44bc-baeb-b2b900411d81", true, "AQAAAAIAAYagAAAAEPamRxHsjUt+zmjPbbPQ4eS05zo3euuHsRHrKrvm+431kl55bteTh7S3yKqO34g3YA==", "fe741f69-25d5-4c94-b89b-0d7746470b92" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd9960df-9e7e-4a3d-8cd4-767bf0b2c0fb",
                column: "NormalizedName",
                value: "SuperAdmin");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd86f795-addb-43d7-885d-eb966325005b",
                column: "NormalizedName",
                value: "User");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbea7556-ee0c-4116-a2ae-f1e377dc6779",
                column: "NormalizedName",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7a9f82-1927-4ca6-81e3-64384b8a2037",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "648e47c5-689e-4201-8ae0-229aca46291e", false, "AQAAAAIAAYagAAAAEOdM0RsuKnr0KOMKkSPaNoxi5X68x+VXx+pFzFwtXf+6Q6ILw/OaUn+1geXBw3c80A==", "24433cd8-a332-432f-b9fc-3b1506b377a9" });
        }
    }
}
