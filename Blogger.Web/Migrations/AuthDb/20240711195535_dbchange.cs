using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class dbchange : Migration
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e442d046-466e-4c3c-9cbf-3f52d881bf59", "AQAAAAIAAYagAAAAELdwtRvFDiDNxGh7rcApU9sNa2D2PLx70c2Mz6DbjdLAMY6PaSaiv0QiAGa82W+YxA==", "30b4b207-3c1a-4b00-84f7-8432ada152e3" });
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0905cfef-f063-42a7-bcb3-4187b0ea8cb2", "AQAAAAIAAYagAAAAENtOIH2DEWq5suc2PDwINyyHLxebifHHXa35JJaOcu2uYvzm8CT9C4qWlLwP605M2A==", "e2f2dc8e-a53b-4c99-9190-d98301f92fa2" });
        }
    }
}
