using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminIdRole = "fbea7556-ee0c-4116-a2ae-f1e377dc6779";
            var superAdminIdRole = "cd9960df-9e7e-4a3d-8cd4-767bf0b2c0fb";
            var userIdRole = "dd86f795-addb-43d7-885d-eb966325005b";

            var roles = new List<IdentityRole>
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = adminIdRole, ConcurrencyStamp = adminIdRole },
                new IdentityRole { Name = "SuperAdmin", NormalizedName = "SUPERADMIN", Id = superAdminIdRole, ConcurrencyStamp = superAdminIdRole },
                new IdentityRole { Name = "User", NormalizedName = "USER", Id = userIdRole, ConcurrencyStamp = userIdRole }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            var superAdminId = "1f7a9f82-1927-4ca6-81e3-64384b8a2037";

            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@blogger.com",
                Email = "superadmin@blogger.com",
                NormalizedEmail = "SUPERADMIN@BLOGGER.COM",
                NormalizedUserName = "SUPERADMIN@BLOGGER.COM",
                Id = superAdminId,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "Superadmin@123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string> { RoleId = adminIdRole, UserId = superAdminId },
                new IdentityUserRole<string> { RoleId = superAdminIdRole, UserId = superAdminId },
                new IdentityUserRole<string> { RoleId = userIdRole, UserId = superAdminId }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
