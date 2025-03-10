using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnChapterBookid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookChapterId",
                table: "UserReport",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChapterBookId",
                table: "UserReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookChapter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChapterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChaperId = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudioUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookType = table.Column<int>(type: "int", nullable: false),
                    WordNo = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ChapterBookId",
                table: "UserReport");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a763aaa-7fd2-4fa0-8ccb-f54eacd92b67", "AQAAAAIAAYagAAAAENF2s1LL18SNLv+cYLYP9PWfbYnSA4yc0Mpeg9v7H7qqGC59cS7zzwdwfQXausWjuw==", "2c6ee9aa-2543-4683-99b7-f138ef9cbe9d" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90074dfd-d20c-43ee-aafb-c1406947772c", "AQAAAAIAAYagAAAAEP8nlwpr6+bBVx8BqsfzGGIlGoO7TIkwwRoczVujwy3KDxWLzCHjsDtYCpopnx8e4A==", "d5c444c1-4e6e-4694-8409-c638f65bee67" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9eb122e3-b2ba-436f-9b82-b3edb64abc05", "AQAAAAIAAYagAAAAELbJ2KHkq17DdaZXnmDc9lBKtNs7hevVYRrg7DOyg3i2dM1AxLPqxc/xzLFxtbs8zw==", "4dfab49e-1019-4eac-b8e8-bf5d8754982d" });
        }
    }
}
