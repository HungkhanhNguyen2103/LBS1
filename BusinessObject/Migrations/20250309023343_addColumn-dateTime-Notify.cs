using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addColumndateTimeNotify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a1f457d-ce22-4d85-81f7-669101693ee5", "AQAAAAIAAYagAAAAEJ/e0zcjzB1x6UrBDS8Ch836Q1jsNy9DWpf02kU2bDh+RbhcoWli6Bf+4iwMichBaw==", "c7850e93-6511-44b9-af32-9b65fda75e37" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85f163d5-e35a-485b-8420-e6c0b83de078", "AQAAAAIAAYagAAAAEEnqpPVIXr46XG3uTh3rPSO9Ys5zyTOn4ODqXEK0uyszub6ILJ4tU2J7BZfLNDV2VA==", "3a0d71c6-1f2d-4814-bbf0-8416081d1165" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b07dcdb-8e78-4af4-9c52-00514974aa81", "AQAAAAIAAYagAAAAEPHEO8YC7AdCrozUps9QoGc8t8It3bMhgsuIa26L66KxTW7J2RO0sbNvtQFO1nqvLw==", "a2e0fc9f-8073-4918-9e44-896ad98b31e1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Notification");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea37ae12-a687-475a-a2a9-b7625055a44c", "AQAAAAIAAYagAAAAEKWjMgsu0mLm1lKl/B/wMXfZFxqaUuLiAjhCPbkB6kOBxMHuBriBfhIfAN1Hh70JaA==", "abc414fb-a2f1-490c-96b1-8c26e5aac08c" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee9dab03-46d9-424f-bba9-2be0647c5e53", "AQAAAAIAAYagAAAAEE0P97pVMHcJUFV8dQXyhuFienb91eMbO6ZGKnicgpkqsADjw1FkjoRO06IKp5qzyQ==", "ac1bace7-2f24-45e5-a9d4-ea646c319598" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e711fbc-f121-4e70-bcd4-7c52171e742c", "AQAAAAIAAYagAAAAEOfs7zqtLPaDbheJtlzvFBKNpDyo3kBoervaPwj9M1CBgeiNSOTr7sXYQSJUq1vm+g==", "3ffcf468-511b-4266-9c7f-0a733413b747" });
        }
    }
}
