using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addcolAvatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "Avatar", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "b9810ead-2881-4ab2-b6aa-7d4e4b39279b", "AQAAAAIAAYagAAAAEBzkl3yxInVYutyZle7pxJAnt6BTjxjUmLZDc43XK5AEAz+Ys+hpX3n7Mc9lwogq0g==", "a84dadab-9f38-486f-966c-7e0f48f12695" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "Avatar", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "5fab1a5d-e858-4e7c-a7cc-91fa9525c6f1", "AQAAAAIAAYagAAAAEMNIY4NEZum0Hv7QRdtMMP0wOmapYXyqKaqVv/88NY9h0+6voQ4vC34Ah80J2QKE4g==", "b9778793-fa99-406b-b9b5-b5a947f51a21" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "Avatar", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "75af1219-3c16-4806-9171-eafc188a5a58", "AQAAAAIAAYagAAAAEPTIhzZ5DbnumDDwMBL37Z/mXHeYxTKvthE/KXAxoGT0GmAFbTDv6rJXBKwLcl6zaQ==", "64ac4684-1e6e-457a-9e2b-9ef10db7dfa3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Account");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c01438e7-75dd-457c-8a60-56a3aeef023b", "AQAAAAIAAYagAAAAEE9phkDYkifuW+PItDLRZKEIWk2+dv1ldhVo83wkxRL0gpd5R5l2v2gsL7l781eNdQ==", "ac11b248-c6f6-4784-ad87-23ed25c72493" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe4b8cd3-b865-41cd-a836-0eac8c84c247", "AQAAAAIAAYagAAAAEMs2Z0U8Ylz7EbMu//uk/4itUTlM8HCJ+SBUCVD5hwrQCh8b9G749kvty5rhKZS2bw==", "e96bdffb-1c41-4c27-b38b-33750de9c80f" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "200bfad3-fb87-40fd-9248-3e5518d2d45f", "AQAAAAIAAYagAAAAEJ2rRoLA78b0DF53j+ChC1qrK+5ZKjUcxBdlcff2HaYD7b92pW4cRMuow7nThy5dsQ==", "795befd2-93a2-4acb-8efd-59c74a94561f" });
        }
    }
}
