using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class changeRelationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "UserReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d233e03c-3a0b-44eb-bb52-54c69836bcc9", "AQAAAAIAAYagAAAAEJ0gPlbjhVhnzkorO09XR+crrY7fktGafSOR9oXCOyUM/rlCoPFnTa9JGgEiqZ43PA==", "021d5351-f869-437b-80d9-a0225968b451" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14fa5dbc-8c0b-41c5-93b6-4e301fc8d745", "AQAAAAIAAYagAAAAEAwvYDEdoIw+aiFEP5lnuHu/cfRiwI4DJTIpYWFaQjgnQBTQr4umoI2HKBrEeyo2zA==", "83eb89bc-34bb-4567-96f8-a1e3f33e7bd9" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb576bd3-6d50-497d-bfe3-ec979a15f7e7", "AQAAAAIAAYagAAAAEAPJhyvldMyHu+7g8uTXomIv5BlgZFgF4fGr29LtkEY6f0VvLFB+JlnQSieZ8V7njg==", "73522e64-e5ba-4216-abfb-db9fda729179" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "UserReport");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1dd80674-aacb-4477-afa2-edcc3fb4a24f", "AQAAAAIAAYagAAAAEFOptep+OaP2nJMhKor63Gt1MsQWNxv8Vy6OOEJ6Oq9H6L+/nrvtJAJA93b4nuYDUQ==", "50043dba-1ee7-4a01-9995-51f56e8fac77" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13a97ec7-ae55-49ff-a9d0-f36c63f59b20", "AQAAAAIAAYagAAAAEDKTS7wIv7776Enm71IR+3lMw2sdBxnGFpd1DpW1y4CYsVIwNnpNx4YCpRnS13lh8w==", "5da434b3-8e54-4cf7-895c-32191ed48208" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "690beff5-d160-46db-ba7b-ba86cad6661b", "AQAAAAIAAYagAAAAEAZOepNLt9g/m4txAhhCOdRaZfH6S2z0T59LO7bTDSdNpjCgYL8RtgroeQvyElN2bA==", "6dcd01ad-d701-4ac4-b1a7-7c3d69c5ec32" });
        }
    }
}
