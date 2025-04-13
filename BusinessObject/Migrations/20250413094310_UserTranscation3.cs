using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class UserTranscation3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "UserTranscation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c76d968c-8684-4bb1-80a4-0c04e78353a4", "AQAAAAIAAYagAAAAEMlccEiXUeR29sKcbAMiiL+UY8NZN3yfs1dOiPMu/EUtroEnptai8daKfVuJVRNAww==", "12d861a0-a050-4d9d-99a3-01a6d86d3a22" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58cc3b32-e6dc-4861-b3f8-4133adc054c7", "AQAAAAIAAYagAAAAEGz/czn2lEvH7TkqXBCOP0ewuXA7WQ9cQrZxPpsfLO6S3Tt+w9TmKTJ8pmmo8LbhOA==", "13688f14-e535-4590-81e9-d684f3c2ae39" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cd33719-0b6e-4d70-a3c1-1787224edc62", "AQAAAAIAAYagAAAAEOrV2N1H7bFhQjQA7U6ozGGzL2+fYCGQztwW+JfvMFCy5WabTwuCITbvbTUbDTJ7mQ==", "d7438b74-6e2c-47fd-ab5d-b721e2794a9d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "UserTranscation");

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
    }
}
