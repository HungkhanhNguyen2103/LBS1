using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addRoleAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "627ec4a3-646f-455f-b65f-2903cf7819b2");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d0ed649-7d70-4877-a329-33c1953059c0", "AQAAAAIAAYagAAAAEMLftL2bRMzmuI0p5kbhwkeks1/Mghpjb2y9TzJraLoSwjVzc8FdN6+SxAObJ92ESA==", "c96dd6f0-a665-4f37-9183-5dbe24042789" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0b8b2a3-986a-4b71-889f-d6d8e19a6956", "AQAAAAIAAYagAAAAEOeHgxvqCDwNwyMlF82I46m569VUMkmxixHv1oPIjqteufPD3E62wOQSq3XZz3KYvA==", "d6e58aec-f564-4ec3-afb8-1a2b373e1e98" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d2b2975-8d03-4cc4-82a2-9ce5f8a25ce6", "AQAAAAIAAYagAAAAEMfULuqsx8oSmkiHoBCyvLqEuBwmyXFVgLHkgfYXj5cW3rctmRWnBxGW0fqHU+E4Xw==", "82389a88-b045-41cd-9506-b44f8518ba7c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "627ec4a3-646f-455f-b65f-2903cf78220f", "7d5002bd-f22f-4c7c-bce1-3d22eed213ff" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "627ec4a3-646f-455f-b65f-2903cf78220f", "7d5002bd-f22f-4c7c-bce1-3d22eed213ff" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6baa78c-0a16-48e6-8535-51884aa00089", "AQAAAAIAAYagAAAAELMsxJlcvZFxrfJi/3JJobQvvTJzq6i2/rOPzSgiSMKDcdyTsLoy3p1BM/ygggF5sg==", "6c58b9f1-dbd1-44b4-9607-3636bd0b3e7d" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9c67909-2905-4e5f-a218-e9b38ba26bd1", "AQAAAAIAAYagAAAAEGVgGnUOFr0ykOeABXvTnHduxbITbw4UNRE3ssfIr2POYvuLWoGb/qAF0OqgvNGJ2A==", "bd551f60-a054-4502-84d9-f8cd2575c963" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfd1a22b-24b3-476f-a1c6-e79d88d7fce7", "AQAAAAIAAYagAAAAEJ6chcTLivk0HgLCiBtpgIKqXzqHFxc7NDETEHOMoh+Mu09v/66Lr9k2RixRm0C8+w==", "dffbf665-471d-445d-9a6c-a8fdf81c1526" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "627ec4a3-646f-455f-b65f-2903cf7819b2", null, "Staff", "STAFF" });
        }
    }
}
