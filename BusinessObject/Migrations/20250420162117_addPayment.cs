using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "UserTranscation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpiredMinute",
                table: "PaymentItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "756c311b-7ad8-4f8c-8ee7-b38daa8f9bb9", "AQAAAAIAAYagAAAAECX3+P6fF2v+hpDsUl8dpPijZ9Z/cBUXZqCHxoXSxwJ1jVO4chfCoUBbUUeSkW6rog==", "415879b1-0d84-41f2-bde2-8b8a991e48e0" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd8e2c8c-5692-4952-b937-f9d8619c9e73", "AQAAAAIAAYagAAAAEIRULcQG/3pLW9yWvGIY4bHfuekhPe7YDHdXnAWrZf3aS+v5VLd5Y2+xue3wuigR+w==", "1232581e-125f-4c20-b68c-1596ad7d7f8f" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e953219-6f41-4e62-9807-193386626ea6", "AQAAAAIAAYagAAAAEDm43DwsR//eK0/CenGRm2HGuM7SHKNYxg5dWm8PbW1P8RpGc5OGLx8jPymwX3Y6qA==", "4e859926-30eb-4563-9589-8463430fd937" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "UserTranscation");

            migrationBuilder.DropColumn(
                name: "ExpiredMinute",
                table: "PaymentItems");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8dfb821-2edd-4d63-82e8-768491366601", "AQAAAAIAAYagAAAAEI0y3/WoNWC88u3+fa8N4VyvraL3gzVpeXTE7Szj5K0gygbdXsrS3qKvXVxDJ943XA==", "b4f789a0-1dd4-4e9f-8068-a8b6446fb6ba" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3d814c1-e0da-4621-9563-4f2206d3e0dc", "AQAAAAIAAYagAAAAEGXLR0rWKOv/orIhLYm30q8M4MmKVy6+ipVjq9PcCb0R5qt09XWJ7oAQV7//48IliQ==", "920a30bf-04f3-4745-84af-64470586bfba" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b96090b-b04d-47bc-932f-f04c9352854a", "AQAAAAIAAYagAAAAEGsNpv/zAlhbcPrfjWO5dvQ6qA7xQp9zDDt5jJx7YzlOwF+Zu0MxkUvKQuJj2HfZUw==", "0c5e2b1b-d84f-4015-a164-e948077d20f7" });
        }
    }
}
