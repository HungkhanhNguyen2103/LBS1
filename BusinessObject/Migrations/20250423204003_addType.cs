using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "UserTranscationBook",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b679062-22a5-4763-9e11-027f137c1d86", "AQAAAAIAAYagAAAAENeok9+I8h9VC2CKpH6OB3CZbDxLtVkObHj0Ibz/jcUrIy7ChXB/V3s/9uY3+ZeOew==", "d4bdd082-3fe3-4790-a96f-882d37a7acb4" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43eb6a9a-79eb-4561-a35d-75d3845ee6a7", "AQAAAAIAAYagAAAAEPMb6Z39rM/nLlEf6AInxCuQ98mf88bTosa86Y6TIgA2taR9B2WanLBmleWuKDM12g==", "a868da99-a183-4133-97ee-29c73ceb36c9" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2b754b3-c927-44ee-bcf0-46e6c0ac896d", "AQAAAAIAAYagAAAAEI+kbZOKy42g1+hhpfU+ZNdBS3rZTAyMxk+XHGwp0KrQQBrymkAG6ygUCwHfHMlzjg==", "bfd17de1-435b-4a83-9a17-70c119fd161b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "UserTranscationBook");

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
    }
}
