using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class changeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReport_BookChapter_BookChapterId",
                table: "UserReport");

            migrationBuilder.DropTable(
                name: "BookChapter");

            migrationBuilder.DropIndex(
                name: "IX_UserReport_BookChapterId",
                table: "UserReport");

            migrationBuilder.DropColumn(
                name: "BookChapterId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookChapterId",
                table: "UserReport",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookChapter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AudioUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookType = table.Column<int>(type: "int", nullable: false),
                    ChaperId = table.Column<int>(type: "int", nullable: false),
                    ChapterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    WordNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookChapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookChapter_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookChapter_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12ebfb04-c0a8-4727-9158-d60f4f516295", "AQAAAAIAAYagAAAAELnedteN9gwvlMYlEVtXGxvJRUdxqjpWlEzZ+Ufn15jRJDfRL2BTKuN8vEchgy0w8w==", "58435fc7-6376-4a23-a606-865eccc090cc" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cab97cac-8871-4c8b-8281-ad976f746c40", "AQAAAAIAAYagAAAAEBagG568Unb77uuQdB06QPIzBTPb9W396AofFy9MtYgpomCZJx9ldjdEy0RgbwItug==", "64175596-d1d6-4728-9888-cc5625e41e1c" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed662221-7d55-43ed-b189-636532908bcf", "AQAAAAIAAYagAAAAEF5osI7SAa8erwfiwb1o+6qKuyZQfjlcAuHe/dcloMExqLS5qbIxodXbbnT+tMQl4g==", "907923fb-012e-4b97-9473-3ae4371cf424" });

            migrationBuilder.CreateIndex(
                name: "IX_UserReport_BookChapterId",
                table: "UserReport",
                column: "BookChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_BookChapter_BookId",
                table: "BookChapter",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookChapter_UserId",
                table: "BookChapter",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReport_BookChapter_BookChapterId",
                table: "UserReport",
                column: "BookChapterId",
                principalTable: "BookChapter",
                principalColumn: "Id");
        }
    }
}
