using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class updateCommentUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0675adee-2800-4780-84ed-4869108a55aa", "AQAAAAIAAYagAAAAEMYkIT1eesJwPWB5APTasomZCtkKx+5EC309uzABVLLKzYw8T7kPYMieaEGTNpgeOg==", "fffb04b1-5b12-42d8-88ee-fb62a5802e81" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32cc04ad-9988-4b36-838b-f98fbd7b2121", "AQAAAAIAAYagAAAAEAyy3J58tVEFGMvoUCYWc8rhJdNnChlcN4q/auB11gSYNtpg6m7ky4o29i/jTNRebw==", "6d421119-99ff-44ac-af43-d8f661edcdeb" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58590602-15c1-4391-aeb8-3c399a759eaf", "AQAAAAIAAYagAAAAEKojrtLt0wjI/Dxc30SwXua0yKRHwIA8zpH9nbT/NwOh1fhxs6sa+xNTbt84yO7b+A==", "8546d2f9-3113-4fdb-ae2c-01f261e57a3b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "708b1ea2-3249-4c90-b592-77957fbded48", "AQAAAAIAAYagAAAAEKIKY/k7pF9wYH1+n9KYg7Jeji1D7F1dDnqDLkc0BjflIVKoAMnnHIrDsP9GlrTFGA==", "8a80b24e-4f9b-48ff-98d4-561bceafaefe" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afdbe6d8-80bd-4a79-bece-aa60b1b74951", "AQAAAAIAAYagAAAAEFyhREeJRAe7ed3ZblTtSapCDJ+x/KCmx4Xcb+SjnY0kyVTuL4Svi9lagTG3jhlvUA==", "2f3b1f59-71a5-4443-ad30-965c2cb2a31d" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7577de8a-9faf-4888-b3b1-611a09fb1e14", "AQAAAAIAAYagAAAAEDC3gQZdmjVq+nveFAz16KeVpivg+ZzHvLwzJNhePJXCxjj6SyAwLShowkk6ztQ/FQ==", "a59ecdfb-a161-4970-be91-3f0852ca9440" });
        }
    }
}
