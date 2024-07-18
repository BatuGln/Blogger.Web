using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class DatabaseUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7a9f82-1927-4ca6-81e3-64384b8a2037",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0a3f56d-2007-4939-aa3c-808b3f96c51f", false, "SUPERADMIN@BLOGGER.COM", "SUPERADMIN@BLOGGER.COM", "AQAAAAIAAYagAAAAEHjOXrmF1cM7rFi9UnlBT6Mg0B/7ZcW350OVEAjilZru3ZjQlx+K8RMhKS4Wlec7fg==", "3bfeff84-58cc-410c-864b-89153c808919" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7a9f82-1927-4ca6-81e3-64384b8a2037",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a265db35-53f2-44bc-baeb-b2b900411d81", true, "SUPERADMİN@BLOGGER.COM", "SUPERADMİN@BLOGGER.COM", "AQAAAAIAAYagAAAAEPamRxHsjUt+zmjPbbPQ4eS05zo3euuHsRHrKrvm+431kl55bteTh7S3yKqO34g3YA==", "fe741f69-25d5-4c94-b89b-0d7746470b92" });
        }
    }
}
