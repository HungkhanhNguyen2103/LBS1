using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class setChangeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b212caa3-2033-45f3-a887-161ac6fc22e4", "AQAAAAIAAYagAAAAEK6me3V/xm1sBwEd7rLuWBW3uvvD2qlJYb3WXFEaRRgLum7/WfARU8y4W8stgtQ2xQ==", "38a0026d-a4bc-42cd-a0c0-4aff09e7c32a" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e992b5a5-d335-49c7-93c0-b1fc17c67b15", "AQAAAAIAAYagAAAAEIr2wiX2VLJvbvZp0z/V3PcDOZ1SlI0fHbofTsUCXAZ0idRcuQl0PB6UAHABV+0MpA==", "c5a03f20-a0fc-4a73-8f37-09810124e14f" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71c74a49-19c1-4a04-8d52-89b4b6decab0", "AQAAAAIAAYagAAAAEOwzuYBpzrZ+WXDhykXMQMcaIXMn1yA/t9fNNgBHH/j2rPZJ95xqsGZ12+Mra2sZGA==", "3297f302-8dfa-4dd7-8789-413fd12ffaa3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b856f06d-3116-4f7a-89e6-10c1c6661493", "AQAAAAIAAYagAAAAENK2cgu5JHDOVLgeSrwU5JgclzdJL5ujndL0lelREE0/kWxtwSW7bVIZzy38p6u1Bg==", "b41bbbfd-0ffa-4340-a113-68e22df073cc" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f87db91-6714-4c34-9ae8-1e1f5653e105", "AQAAAAIAAYagAAAAEAKkATielwmdfSdLDXpSpGqaZTCMsaRITZ8oFyhl3AeOZd7McOo7BFUZvUUt6EGicQ==", "13e31634-dcef-4f41-abdf-3d5f1ba2a673" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd9658b2-4ae1-49fb-9c0e-857d49a3e9e1", "AQAAAAIAAYagAAAAENV0JuE1gLRMqr0CupALxt/ASfc9yvh+JSg001ZbRTyEdLcV5nYoFyIYEmD5p/mLIg==", "8163e9db-6775-4af5-9ce2-e712d77c14a5" });
        }
    }
}
