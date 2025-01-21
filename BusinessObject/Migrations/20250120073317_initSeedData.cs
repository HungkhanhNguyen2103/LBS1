using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class initSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccessFailedCount", "AccountActive", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResetPassword", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7d5002bd-f22f-4c7c-bce1-3d22eed213ff", 0, false, null, "0b7a0b17-4347-412c-a013-8cd259cf7065", "admin@gmail.com", false, "Admin", 0, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEPnWiwbF3aEmRbFW4dM5U1MroibXB1ipm730NTMkhXjP16my3bkAYPpvm8fOSJ6kmg==", null, false, 0, "dcb3b98d-e3ac-4e57-934b-1611adad195e", false, "admin" },
                    { "7d5002bd-f22f-4c7c-bce1-3d22eff321ef", 0, false, null, "15868085-72f7-49ea-b2c3-49663517adb1", "staff@gmail.com", false, "Staff", 0, false, null, null, "STAFF", "AQAAAAIAAYagAAAAEHtpOXnHh+a7WeIQrIepA57g9EDdV1rTkT62gFdGmaqHk+BFtAQCXaYith9njJVfSg==", null, false, 0, "6570a8a2-18e0-47d8-868f-34685f49ca3a", false, "staff" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46118fe1-2d15-4c5b-82f9-bc2f19b4a7c3", null, "Admin", "ADMIN" },
                    { "627ec4a3-646f-455f-b65f-2903cf7819b2", null, "Staff", "STAFF" },
                    { "627ec4a3-646f-455f-b65f-2903f87c19b6", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "46118fe1-2d15-4c5b-82f9-bc2f19b4a7c3", "7d5002bd-f22f-4c7c-bce1-3d22eed213ff" },
                    { "627ec4a3-646f-455f-b65f-2903cf7819b2", "7d5002bd-f22f-4c7c-bce1-3d22eff321ef" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "627ec4a3-646f-455f-b65f-2903f87c19b6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "46118fe1-2d15-4c5b-82f9-bc2f19b4a7c3", "7d5002bd-f22f-4c7c-bce1-3d22eed213ff" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "627ec4a3-646f-455f-b65f-2903cf7819b2", "7d5002bd-f22f-4c7c-bce1-3d22eff321ef" });

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46118fe1-2d15-4c5b-82f9-bc2f19b4a7c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "627ec4a3-646f-455f-b65f-2903cf7819b2");
        }
    }
}
