using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class updateaccountAcvie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "AccountActive", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { true, "ab5ad67d-14db-4356-969d-28788b4c659a", "AQAAAAIAAYagAAAAEGjOxU5OXCfA8bE3oqO8TWCUp9lm2p0TSm0BQMHaLOvE+I7mELis9+lkhuDy4Dafog==", "291a3f80-be97-4d8e-9579-f44eb7f5d093" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef",
                columns: new[] { "AccountActive", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { true, "d026456b-434c-4658-a88e-602307c23e32", "AQAAAAIAAYagAAAAEFfJkT21bQA7xXWw0LlkMA9HcwgXgNS8MhxttcaZM/mPxY99erVsLR9Gty+cCAAEXQ==", "dbb0ac40-4fbc-4798-a54b-a9f421dc60f0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "AccountActive", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { false, "0b7a0b17-4347-412c-a013-8cd259cf7065", "AQAAAAIAAYagAAAAEPnWiwbF3aEmRbFW4dM5U1MroibXB1ipm730NTMkhXjP16my3bkAYPpvm8fOSJ6kmg==", "dcb3b98d-e3ac-4e57-934b-1611adad195e" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef",
                columns: new[] { "AccountActive", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { false, "15868085-72f7-49ea-b2c3-49663517adb1", "AQAAAAIAAYagAAAAEHtpOXnHh+a7WeIQrIepA57g9EDdV1rTkT62gFdGmaqHk+BFtAQCXaYith9njJVfSg==", "6570a8a2-18e0-47d8-868f-34685f49ca3a" });
        }
    }
}
