using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addBookCategory2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCategory_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2bd8844-cb78-49dc-9400-481e78cffcd6", "AQAAAAIAAYagAAAAENBLLISoCyqoTc4rH0KFSi2RO/fYARgIq2dXWPOkqO4Y62jd1tXN5XhfkEjKFqEuDw==", "aab36b74-d7a5-4b67-87fb-bc47c017b44a" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ebc205e-7272-49e5-b5fe-2f1150573798", "AQAAAAIAAYagAAAAEKTfbnFZNK7tKlgC+XjNPbtok310JUWnNhDst3LAI4zZIlqjKymUmAqlQy+D3gUNKw==", "481e5876-cba4-406f-8bcc-b6ca2fbfe860" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "422648c2-50c8-4f3d-a9b0-e53e1044bc4a", "AQAAAAIAAYagAAAAEJoWOwINDQL2rZa+68g488wYkyEZGjcAAewxexPzyAaSIV2ZQuNYmWkwHhtIrEqHPg==", "76a93850-09ef-44ca-9993-00918b99a3e9" });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_BookId",
                table: "BookCategory",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategory");

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
    }
}
