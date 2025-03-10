using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class updaterolemanager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "418b9be0-3b86-4cc8-9b38-e12daede6095", "AQAAAAIAAYagAAAAECkDKxMEjbyO5qEDhwSxehzws2q/p3kI9dNAXdyw5UkFvU3AH5d/FHQJ3M1sFUjDHA==", "5cb1758a-dd51-4e9b-bd9a-3084055c36dd" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccessFailedCount", "AccountActive", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResetPassword", "SecurityStamp", "SocialAccount", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7d5002bd-f22f-4c7c-bce1-3d22eed213dd", 0, true, null, "b98020aa-d12e-413a-9bbc-d63fb320eee8", "manager@gmail.com", false, "Manager", 0, false, null, null, "MANAGER", "AQAAAAIAAYagAAAAEI8BMZHw4sgRNArauD6A3+rc9lKQG2+D5rQ1HkCsuPOUQ0pn6VVSooEUhv0oZcn86A==", null, false, 0, "a6e146f1-3c39-45df-9b57-ff576fcfe04f", false, false, "manager" },
                    { "7d5002bd-f22f-4c7c-bce1-3d22eff012ef", 0, true, null, "3802a33b-1354-401a-8c17-9129566ec51e", "author@gmail.com", false, "Author", 0, false, null, null, "AUTHOR", "AQAAAAIAAYagAAAAEEG7AVlp9r0ii0PuFREoEd7+w8PmD1B6qvTPGHT7i4EVk2gN/VW2PNo/b+DhvhkX+Q==", null, false, 0, "1fb1771d-45d3-4b91-90a8-35cac14eee8c", false, false, "author" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "627ec4a3-646f-455f-b65f-2903cf7820f2", null, "Author", "AUTHOR" },
                    { "627ec4a3-646f-455f-b65f-2903cf78220f", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "627ec4a3-646f-455f-b65f-2903f87c19b6", "7d5002bd-f22f-4c7c-bce1-3d22eed213ff" },
                    { "627ec4a3-646f-455f-b65f-2903cf78220f", "7d5002bd-f22f-4c7c-bce1-3d22eed213dd" },
                    { "627ec4a3-646f-455f-b65f-2903cf7820f2", "7d5002bd-f22f-4c7c-bce1-3d22eff012ef" },
                    { "627ec4a3-646f-455f-b65f-2903f87c19b6", "7d5002bd-f22f-4c7c-bce1-3d22eff012ef" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "627ec4a3-646f-455f-b65f-2903cf78220f", "7d5002bd-f22f-4c7c-bce1-3d22eed213dd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "627ec4a3-646f-455f-b65f-2903f87c19b6", "7d5002bd-f22f-4c7c-bce1-3d22eed213ff" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "627ec4a3-646f-455f-b65f-2903cf7820f2", "7d5002bd-f22f-4c7c-bce1-3d22eff012ef" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "627ec4a3-646f-455f-b65f-2903f87c19b6", "7d5002bd-f22f-4c7c-bce1-3d22eff012ef" });

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "627ec4a3-646f-455f-b65f-2903cf7820f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "627ec4a3-646f-455f-b65f-2903cf78220f");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a9c9e70-254e-41ea-a7f0-6e3c3de08c04", "AQAAAAIAAYagAAAAEP8KHk2FcqreH0McypjIruA+htPsKosV/T554g2ulWS2s7AHiw3C3VSCTcvjb0lMFQ==", "d1fcb8fd-5171-4e24-9830-769823a0af90" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccessFailedCount", "AccountActive", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResetPassword", "SecurityStamp", "SocialAccount", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7d5002bd-f22f-4c7c-bce1-3d22eff321ef", 0, true, null, "c0d569df-21b4-40b6-be39-2dee2b57b61a", "staff@gmail.com", false, "Staff", 0, false, null, null, "STAFF", "AQAAAAIAAYagAAAAEAfHQcQxvOLgmAS9BVaYT8PWLGzeq51p8aj6LARTi1ASHOk+Yr04ECDK7jmCAYfGFA==", null, false, 0, "7136313d-1cc3-4732-937d-534efba986ad", false, false, "staff" });
        }
    }
}
