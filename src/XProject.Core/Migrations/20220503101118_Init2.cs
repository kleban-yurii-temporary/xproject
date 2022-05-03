using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XProject.Core.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0b0d56b1-6089-45d1-a416-915e31b83b9f", "5a6856fb-4732-423f-8e92-38bb8abf3666" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "57a6481e-70b0-437b-8b41-2deb5f330975", "5a6856fb-4732-423f-8e92-38bb8abf3666" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0b0d56b1-6089-45d1-a416-915e31b83b9f", "6631ca9f-3b61-43bd-ad2a-783d8ac9f4d5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b0d56b1-6089-45d1-a416-915e31b83b9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57a6481e-70b0-437b-8b41-2deb5f330975");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a6856fb-4732-423f-8e92-38bb8abf3666");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6631ca9f-3b61-43bd-ad2a-783d8ac9f4d5");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "LossesEquipment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a300ff7-129c-4562-8626-c1839197da79", "2a300ff7-129c-4562-8626-c1839197da79", "User", "USER" },
                    { "79f3375c-be74-49ba-949e-ce802655b352", "79f3375c-be74-49ba-949e-ce802655b352", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "04bb431f-e3b3-48c4-bf7b-a21bce290e36", 0, "47eb98f2-efce-4c41-868e-db753e249431", "user@xproject.com", true, null, null, false, null, null, "USER@XPROJECT.COM", "AQAAAAEAACcQAAAAEJvxWMNogRjAjFkCtSxVYJAvKTNZRCUByLuUc8JIOUrCQBF3olH6B4MKBk73cdZAEA==", null, false, "e915dd7f-aba2-4b7e-9f19-6c935e03ecdc", false, "user@xproject.com" },
                    { "dbf3c283-1e6a-4a1e-9481-767e1850319e", 0, "d8f45631-3814-47e5-b0eb-589d6a935d55", "admin@xproject.com", true, null, null, false, null, null, "ADMIN@XPROJECT.COM", "AQAAAAEAACcQAAAAEAuT8a/oUmtFccqp82ik27eFBaksIJLYrRc7eIUttezSN8bpKaQnzgL8c02m527ZpQ==", null, false, "dbc048a3-bd15-4e34-b349-3e69481d4c8a", false, "admin@xproject.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2a300ff7-129c-4562-8626-c1839197da79", "04bb431f-e3b3-48c4-bf7b-a21bce290e36" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2a300ff7-129c-4562-8626-c1839197da79", "dbf3c283-1e6a-4a1e-9481-767e1850319e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "79f3375c-be74-49ba-949e-ce802655b352", "dbf3c283-1e6a-4a1e-9481-767e1850319e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2a300ff7-129c-4562-8626-c1839197da79", "04bb431f-e3b3-48c4-bf7b-a21bce290e36" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2a300ff7-129c-4562-8626-c1839197da79", "dbf3c283-1e6a-4a1e-9481-767e1850319e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "79f3375c-be74-49ba-949e-ce802655b352", "dbf3c283-1e6a-4a1e-9481-767e1850319e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a300ff7-129c-4562-8626-c1839197da79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79f3375c-be74-49ba-949e-ce802655b352");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04bb431f-e3b3-48c4-bf7b-a21bce290e36");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbf3c283-1e6a-4a1e-9481-767e1850319e");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "LossesEquipment");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b0d56b1-6089-45d1-a416-915e31b83b9f", "0b0d56b1-6089-45d1-a416-915e31b83b9f", "User", "USER" },
                    { "57a6481e-70b0-437b-8b41-2deb5f330975", "57a6481e-70b0-437b-8b41-2deb5f330975", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5a6856fb-4732-423f-8e92-38bb8abf3666", 0, "5aff00af-5316-4f0a-9940-5711a354c0ff", "admin@xproject.com", true, null, null, false, null, null, "ADMIN@XPROJECT.COM", "AQAAAAEAACcQAAAAEIrO6sVKRRY2+bB+0dNpWmJoc3kpG/fT9fMTqFmqaTGXndw4aTFgvNZDZ0N9PCx+9g==", null, false, "67b21f03-4843-488a-bc72-7221a516ce9e", false, "admin@xproject.com" },
                    { "6631ca9f-3b61-43bd-ad2a-783d8ac9f4d5", 0, "bdd6243b-25f5-4382-adfd-b995d0c5d4a8", "user@xproject.com", true, null, null, false, null, null, "USER@XPROJECT.COM", "AQAAAAEAACcQAAAAELe07EVPv8eOroE1xBrqIHk07Pl4Eo/UZQ+z13yvJViBKZaPjSoc4TTTW4++MYWRow==", null, false, "c2ded625-5f4f-4644-b0b9-a4d94e8ab557", false, "user@xproject.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0b0d56b1-6089-45d1-a416-915e31b83b9f", "5a6856fb-4732-423f-8e92-38bb8abf3666" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "57a6481e-70b0-437b-8b41-2deb5f330975", "5a6856fb-4732-423f-8e92-38bb8abf3666" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0b0d56b1-6089-45d1-a416-915e31b83b9f", "6631ca9f-3b61-43bd-ad2a-783d8ac9f4d5" });
        }
    }
}
