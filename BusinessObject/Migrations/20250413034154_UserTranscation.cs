using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class UserTranscation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payment",
                table: "UserTranscation");

            migrationBuilder.RenameColumn(
                name: "PaymentStatus",
                table: "UserTranscationBook",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "PaymentType",
                table: "UserTranscation",
                newName: "PaymentItemId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserTranscationBook",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChapterId",
                table: "UserTranscationBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserTranscation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_UserTranscation_PaymentItemId",
                table: "UserTranscation",
                column: "PaymentItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTranscation_PaymentItems_PaymentItemId",
                table: "UserTranscation",
                column: "PaymentItemId",
                principalTable: "PaymentItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTranscation_PaymentItems_PaymentItemId",
                table: "UserTranscation");

            migrationBuilder.DropIndex(
                name: "IX_UserTranscation_PaymentItemId",
                table: "UserTranscation");

            migrationBuilder.DropColumn(
                name: "ChapterId",
                table: "UserTranscationBook");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "UserTranscationBook",
                newName: "PaymentStatus");

            migrationBuilder.RenameColumn(
                name: "PaymentItemId",
                table: "UserTranscation",
                newName: "PaymentType");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserTranscationBook",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserTranscation",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Payment",
                table: "UserTranscation",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
