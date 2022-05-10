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

            builder.Entity<EquipmentType>().HasData(
                new EquipmentType
                {
                    Id = 1,
                    Title = "Літаки",
                    FileTitle = "aircraft",
                    IconPath = "/img/icons/aircraft.png",
                    Order = 1
                },
                new EquipmentType
                {
                    Id = 2,
                    Title = "Гвинтокрили",
                    FileTitle = "helicopter",
                    IconPath = "/img/icons/helicopter.png",
                    Order = 2
                },
                new EquipmentType
                {
                    Id = 3,
                    Title = "Дрони",
                    FileTitle = "drone",
                    IconPath = "/img/icons/drone.png",
                    Order = 3
                },
                new EquipmentType
                {
                    Id = 4,
                    Title = "ППО",
                    FileTitle = "anti-aircraft warfare",
                    IconPath = "/img/icons/anti-aircraft-warfare.png",
                    Order = 5
                },
                new EquipmentType
                {
                    Id = 5,
                    Title = "Крилаті ракети",
                    FileTitle = "cruise missiles",
                    IconPath = "/img/icons/cruise-missiles.png",
                    Order = 5
                },
                new EquipmentType
                {
                    Id = 6,
                    Title = "Танки",
                    FileTitle = "tank",
                    IconPath = "/img/icons/tank.png",
                    Order = 6
                },
                new EquipmentType
                  {
                      Id = 7,
                      Title = "БТР",
                      FileTitle = "APC",
                      IconPath = "/img/icons/apc.png",
                      Order = 7
                  },
                new EquipmentType
                {
                    Id = 8,
                    Title = "Артилерія",
                    FileTitle = "field artillery",
                    IconPath = "/img/icons/field-artillery.png",
                    Order = 8
                },
                new EquipmentType
                  {
                      Id = 9,
                      Title = "РСЗВ",
                      FileTitle = "MLP",
                      IconPath = "/img/icons/mlr.png",
                      Order = 9
                  },
                new EquipmentType
                {
                    Id = 10,
                    Title = "Техніка і цистерни з ПММ",
                    FileTitle = "vehicles and fuel tanks",
                    IconPath = "/img/icons/vehicles-and-fuel-tanks.png",
                    Order = 10
                },
                new EquipmentType
                {
                    Id = 11,
                    Title = "Морські кораблі",
                    FileTitle = "naval ship",
                    IconPath = "/img/icons/naval-ship.png",
                    Order = 11
                },
                 new EquipmentType
                 {
                     Id = 12,
                     Title = "Спец. обладнання",
                     FileTitle = "special equipment",
                     IconPath = "/img/icons/special-equipment.png",
                     Order = 12
                 });

            builder.Entity<Option>().HasData(
                new Option { Key = "start_date", Value = "24.02.2022" },
                new Option { Key = "last_update", Value = "1900.01.01"}
                );
        }
    }
}
