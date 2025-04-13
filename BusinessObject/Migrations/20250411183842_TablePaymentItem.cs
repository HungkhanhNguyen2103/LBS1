using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class TablePaymentItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AmountMoney = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentItems", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0c6eaeb-2c49-4353-acc3-6a6c8eef1f7f", "AQAAAAIAAYagAAAAEEh3he2li1GtOT46sCFme1fJswDpc5+glv15IvD8q0xmn5PZFbDUYvJHbg0jCsrpSg==", "225e06cc-0d75-4644-a782-d694e64ae3e3" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4ce1cfe-41da-4a1d-89d6-d62114b2a89a", "AQAAAAIAAYagAAAAEJtMSNfIM7hVLnmMK90pNN9hIYBi21aFKUyDoINQLBOGgHQ7GqVOvcHEJlmBLc8zIQ==", "e443a693-efd0-4830-b8aa-355134ecd5cb" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e33d4dbe-3b3f-411d-9ffa-f36213586708", "AQAAAAIAAYagAAAAEN3+RCVIz4WA6Z6eNsiGJk2MWjjkyGjf+mDoBT1Chpvhiq7sxiAioaszzhEglQg1lw==", "4fc94bad-ae92-4b0f-9951-526872bdcd26" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentItems");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1f23960-7ac2-4143-ae2f-d288d0bc98dc", "AQAAAAIAAYagAAAAEPtDOjAXCcWsGY8x18C5d+rEfPJbAmoLq9Vh6IJzJK9vkf7P6kZOj5JlDL2Tl5ySUQ==", "a63e359a-6c72-4658-b7d3-23aeac3263e7" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0762549d-d29e-4b62-888c-18976b49f404", "AQAAAAIAAYagAAAAEAUtvFbWrnfQnHqZyAkn54507xM54graKfL37E//v8FyTeO8VyhDLd7sLbEtxtIkmw==", "744fcd24-ab06-4322-b395-aff3d3d2bf99" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5112d2b-6a69-4757-bf0f-99f58620eb7c", "AQAAAAIAAYagAAAAEGWVMgBquFowj2uo/q+atDjJIk7rBtG2FBGcxAt/jjmGHXy5UO+i2C1ebO6PhrzzUw==", "ac50f31b-2f24-4804-b822-aaa256cace2f" });
        }
    }
}
