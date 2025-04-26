using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTranscation");

            migrationBuilder.DropTable(
                name: "UserTranscationBook");

            migrationBuilder.DropColumn(
                name: "ChapterId",
                table: "CommentUsers");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "CommentUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NotificationManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotifitiType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationManagers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentItemId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTransaction_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTransaction_PaymentItems_PaymentItemId",
                        column: x => x.PaymentItemId,
                        principalTable: "PaymentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTransactionBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTransactionBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTransactionBook_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTransactionBook_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6baa78c-0a16-48e6-8535-51884aa00089", "AQAAAAIAAYagAAAAELMsxJlcvZFxrfJi/3JJobQvvTJzq6i2/rOPzSgiSMKDcdyTsLoy3p1BM/ygggF5sg==", "6c58b9f1-dbd1-44b4-9607-3636bd0b3e7d" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9c67909-2905-4e5f-a218-e9b38ba26bd1", "AQAAAAIAAYagAAAAEGVgGnUOFr0ykOeABXvTnHduxbITbw4UNRE3ssfIr2POYvuLWoGb/qAF0OqgvNGJ2A==", "bd551f60-a054-4502-84d9-f8cd2575c963" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfd1a22b-24b3-476f-a1c6-e79d88d7fce7", "AQAAAAIAAYagAAAAEJ6chcTLivk0HgLCiBtpgIKqXzqHFxc7NDETEHOMoh+Mu09v/66Lr9k2RixRm0C8+w==", "dffbf665-471d-445d-9a6c-a8fdf81c1526" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTransaction_PaymentItemId",
                table: "UserTransaction",
                column: "PaymentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTransaction_UserId",
                table: "UserTransaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTransactionBook_BookId",
                table: "UserTransactionBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTransactionBook_UserId",
                table: "UserTransactionBook",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationManagers");

            migrationBuilder.DropTable(
                name: "UserTransaction");

            migrationBuilder.DropTable(
                name: "UserTransactionBook");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "CommentUsers");

            migrationBuilder.AddColumn<string>(
                name: "ChapterId",
                table: "CommentUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserTranscation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTranscation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTranscation_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTranscation_PaymentItems_PaymentItemId",
                        column: x => x.PaymentItemId,
                        principalTable: "PaymentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTranscationBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTranscationBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTranscationBook_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTranscationBook_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserTranscation_PaymentItemId",
                table: "UserTranscation",
                column: "PaymentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTranscation_UserId",
                table: "UserTranscation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTranscationBook_BookId",
                table: "UserTranscationBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTranscationBook_UserId",
                table: "UserTranscationBook",
                column: "UserId");
        }
    }
}
