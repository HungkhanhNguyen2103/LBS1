using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addBanktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChapterBookId",
                table: "UserReport");

            migrationBuilder.CreateTable(
                name: "AuthorTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorTransactions_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17ca6353-860c-46f0-9e33-a3eb404ebc48", "AQAAAAIAAYagAAAAEGmHTz3YyxuKtKv7zmOyUyFeZ69GaXZgtj/dRerUUSmiD2b1w8xZMHSKDklbscczQw==", "45685d18-7e11-4078-a553-d3587c0836d8" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a44a59e-5ddc-4b22-b92f-4aead5000c9e", "AQAAAAIAAYagAAAAEEHAG9x+Zm+Q/fqjOjriItIebDfprD6LnVYSIHZ1zeZFjvnZFkE1fQBg5WoA4nPudw==", "8c788afa-197d-421e-a13c-ab15a5f5b4d2" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb2c5425-2c34-4b97-a60a-1cc1021086f5", "AQAAAAIAAYagAAAAEBYD7iSMwQt/AKLhPiHUAZ7hRX+RgsPyykq3XkhUwUAbwf2PoPfCau81eVYKEcIT5g==", "551d20a4-dea5-4381-b984-cb49096e5b9d" });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorTransactions_UserId",
                table: "AuthorTransactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_UserId",
                table: "Banks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorTransactions");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.AddColumn<string>(
                name: "ChapterBookId",
                table: "UserReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d0ed649-7d70-4877-a329-33c1953059c0", "AQAAAAIAAYagAAAAEMLftL2bRMzmuI0p5kbhwkeks1/Mghpjb2y9TzJraLoSwjVzc8FdN6+SxAObJ92ESA==", "c96dd6f0-a665-4f37-9183-5dbe24042789" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0b8b2a3-986a-4b71-889f-d6d8e19a6956", "AQAAAAIAAYagAAAAEOeHgxvqCDwNwyMlF82I46m569VUMkmxixHv1oPIjqteufPD3E62wOQSq3XZz3KYvA==", "d6e58aec-f564-4ec3-afb8-1a2b373e1e98" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d2b2975-8d03-4cc4-82a2-9ce5f8a25ce6", "AQAAAAIAAYagAAAAEMfULuqsx8oSmkiHoBCyvLqEuBwmyXFVgLHkgfYXj5cW3rctmRWnBxGW0fqHU+E4Xw==", "82389a88-b045-41cd-9506-b44f8518ba7c" });
        }
    }
}
