using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addFieldSocialAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SocialAccount",
                table: "Account",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "SocialAccount" },
                values: new object[] { "bc3e3303-ffbd-4d02-aa79-2ef46dafb82b", "AQAAAAIAAYagAAAAEEjOQbIDP+Jnq/ynFUyXGcfF6whGkkK6hoxKownbmrzhrhQP57NsKKZ8fIwR1AhAiw==", "e88fe90c-5b6a-4d54-85db-8a5c1c0fe325", false });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "SocialAccount" },
                values: new object[] { "f9f9d2d3-54d7-47b8-9a76-21cf24ef2110", "AQAAAAIAAYagAAAAEC7ky6QecoXhFy0WfmJ9vLa5D2JfYL0rtc9KwmuvgeoPmr6RcNNQYkF07UGdLHC8/g==", "2fe72cca-6af3-4083-842f-808b6d57e9ac", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialAccount",
                table: "Account");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab5ad67d-14db-4356-969d-28788b4c659a", "AQAAAAIAAYagAAAAEGjOxU5OXCfA8bE3oqO8TWCUp9lm2p0TSm0BQMHaLOvE+I7mELis9+lkhuDy4Dafog==", "291a3f80-be97-4d8e-9579-f44eb7f5d093" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff321ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d026456b-434c-4658-a88e-602307c23e32", "AQAAAAIAAYagAAAAEFfJkT21bQA7xXWw0LlkMA9HcwgXgNS8MhxttcaZM/mPxY99erVsLR9Gty+cCAAEXQ==", "dbb0ac40-4fbc-4798-a54b-a9f421dc60f0" });
        }
    }
}
