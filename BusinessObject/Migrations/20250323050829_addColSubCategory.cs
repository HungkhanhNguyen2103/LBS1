using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addColSubCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_CategoryId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Book");

            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99f01746-f81e-4ffb-8dcb-a3ae0ca736b4", "AQAAAAIAAYagAAAAECFxqDYRUhALgiYLpfJmzojkEJp1WGKPiBihS+VdLwS1v1R3qCRNe3jPVZmgLoonHA==", "64c9128f-c423-490f-9b3a-bb27da054ee2" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36d3df72-7eb1-458b-8e59-548275a2584b", "AQAAAAIAAYagAAAAEIEDn9PlJg47J3JAWkWhf2ixP8Hq4mNtE5wntDTo4lLjJGAINaolhtWxDrWyh+j3vw==", "8c8cd958-85ee-4df6-aa9b-4a0889d4981d" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0633128-ac60-42ff-b2d6-06dab2e0e8fd", "AQAAAAIAAYagAAAAEFgudglSOq8c+Faq1vzmuN04gwQ4ovuuMh7jJWGXMsFRUIyGhr9TbbYJSmgTHicbDA==", "67466a4a-8619-4877-816d-1d9f8fa8b703" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd37b157-8428-4c6c-9a4e-c6e8b397480b", "AQAAAAIAAYagAAAAEJAdKpGLLbKr4t6ecboARo2PckPucNfr/PgfY2+Bv89Z+HGa66MmWCtjBNqCoRO8Fg==", "620ddaa8-288c-405f-b1ed-e14534173ce4" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adfd4836-fd12-42eb-a0d4-e927a8873610", "AQAAAAIAAYagAAAAEKH7AUUFZ570rVRG7vgEKULkKnSDrFl2nASFfzOdsndRtVMoNXeFa2qJDsDFcHwwCA==", "2686bf8c-08f2-4a75-85a1-e2d6f01d2dfc" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfa1e3a0-1bf4-49ee-b01a-f9b52945c830", "AQAAAAIAAYagAAAAEK/jIYhBzexAlU/puLoEL6TemdVjHz/UEo2K5MW0iIOHQi/XIEyTrU5WmtXr+snivg==", "ee65d211-0b49-417c-8753-a798e18b53a9" });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
