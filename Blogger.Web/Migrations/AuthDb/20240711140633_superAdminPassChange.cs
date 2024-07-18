using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class superAdminPassChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7a9f82-1927-4ca6-81e3-64384b8a2037",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0905cfef-f063-42a7-bcb3-4187b0ea8cb2", "AQAAAAIAAYagAAAAENtOIH2DEWq5suc2PDwINyyHLxebifHHXa35JJaOcu2uYvzm8CT9C4qWlLwP605M2A==", "e2f2dc8e-a53b-4c99-9190-d98301f92fa2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7a9f82-1927-4ca6-81e3-64384b8a2037",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ba0da31-3ba3-49c8-8de4-ca74dfb15c9d", "AQAAAAIAAYagAAAAEOa+qKmIwF/uOGAgGLfzQ6YLNriZFCjPOQFWn50QfOFYuNTag0b3kidG2pQHbBP9Rw==", "22619821-b781-49e9-95a0-62d46b60be04" });
        }
    }
}
