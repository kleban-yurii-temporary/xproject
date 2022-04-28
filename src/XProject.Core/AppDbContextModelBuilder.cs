using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Core
{
    public static class AppDbContextModelBuilder
    {
        public static void Seed(this ModelBuilder builder)
        {
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Id = ADMIN_ROLE_ID,
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = ADMIN_ROLE_ID
                    },
                    new IdentityRole
                    {
                        Id = USER_ROLE_ID,
                        Name = "User",
                        NormalizedName = "USER",
                        ConcurrencyStamp = USER_ROLE_ID
                    }
                );

            string ADMIN_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();

            var adminUser = new AppUser
            {
                Id = ADMIN_ID,
                UserName = "admin@xproject.com",
                EmailConfirmed = true,
                NormalizedUserName = "admin@xproject.com".ToUpper(),
                Email = "admin@xproject.com"
            };

            var editorUser = new AppUser
            {
                Id = USER_ID,
                UserName = "user@xproject.com",
                EmailConfirmed = true,
                NormalizedUserName = "user@xproject.com".ToUpper(),
                Email = "user@xproject.com"
            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@123$g");
            editorUser.PasswordHash = passwordHasher.HashPassword(editorUser, "User@123$g");

            builder.Entity<AppUser>()
                .HasData(adminUser, editorUser);

            builder.Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = ADMIN_ROLE_ID,
                        UserId = ADMIN_ID
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = USER_ROLE_ID,
                        UserId = ADMIN_ID
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = USER_ROLE_ID,
                        UserId = USER_ID
                    }
                );
        }
    }
}
