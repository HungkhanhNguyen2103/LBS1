using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class UserTranscation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "UserTranscation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "UserTranscation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf3bdb61-f0f2-48c3-adb0-54c453d520d1", "AQAAAAIAAYagAAAAEF8uVGYrcTFeEVnGptoOg8WQXMCLLH8Nws9wEk0WVXVJVMtw6d8Lbua9zfoYrc2h0Q==", "6c883ecc-5359-4c9d-aeb1-9b7097ebec1f" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba27f61b-4744-4822-aee5-a08d4d74fa0a", "AQAAAAIAAYagAAAAEOoIdtFpNr9sCNVExYMSDSPTMZ5pE4hdyQ0XWPkXc5iwzXnM8yPX9wgh0zqgl9Aa3w==", "b056eb90-a606-4598-93c5-0635f1384145" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78b130df-cb9e-4a3c-9f85-d8e5dae855d8", "AQAAAAIAAYagAAAAEB1Bg9KZlR3XlRSf0/pciadnCjYtbM5Hw0ywztnYuIh+GYGbcwi9zKcQ/q4wbE1Q4w==", "cc620b56-8382-45e8-8797-0802c8013642" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "UserTranscation");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "UserTranscation");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3af1808c-63fb-4c6e-958f-e8389c607e60", "AQAAAAIAAYagAAAAENcoAoJP9fLse8Mar2Dn8TQe5XOjhk5PJ/Eck9r6OLfkmzIfBlMDkUjU/BLuYBDdQA==", "1af36c00-03f6-4d2d-ab99-befe8ee92c0a" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4976961-600f-4bdc-98cf-6e57cee8128c", "AQAAAAIAAYagAAAAEJ5IFnU+lENPAQx3RQq7Rr/Wo+TQQ12SsoOtymCzVA/byBIZtKCLELFpCyVbpVEc4A==", "97e14dc2-adfe-4a04-96c6-49cfa3f81ba1" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad5aa046-f28c-46af-9931-faab5637443b", "AQAAAAIAAYagAAAAEOs0Ij3LImlKdXK0vjNTxl5OfxJzaQPuCqNl8LvLBhG3H62IhNjv3ET9J0tcGCD5Zw==", "ff75dd55-95ee-4dd3-8351-ef27911c5511" });
        }
    }
}
