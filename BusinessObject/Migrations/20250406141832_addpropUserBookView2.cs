using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addpropUserBookView2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "509d167b-ef94-443c-983f-30cb2ac7b285", "AQAAAAIAAYagAAAAEOZwi6VqOGYEjmzs/EEyi0jVCdwcI5HnD8oI9gbvyrXlJgi+TYWpc+KIGqeWqGI9Kw==", "7aae4a72-1c5b-414b-8e22-e4f973765f38" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c155d00-752e-4838-b323-a4fa5f2ab3bf", "AQAAAAIAAYagAAAAEMNIKRohLZIyNqOPur57Fp45VbtwfY5MM8wXbATp9DIEchRCL6zElB10t2auRwRqfA==", "f24b5934-b208-4f83-b2c8-94ff7e8d7ba2" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fbc2b31-8edf-40e6-8add-fe69c4900da7", "AQAAAAIAAYagAAAAEIFaeX0lISKsFJrPfMM6NhXQbKTXToDcOzji+mub/lluYpvSmIKS6ZqEWJvGgbEn4g==", "8da3decf-a59f-40a6-94c7-b5a9084f42de" });

            migrationBuilder.CreateIndex(
                name: "IX_UserBookView_BookId",
                table: "UserBookView",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBookView_Book_BookId",
                table: "UserBookView",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBookView_Book_BookId",
                table: "UserBookView");

            migrationBuilder.DropIndex(
                name: "IX_UserBookView_BookId",
                table: "UserBookView");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "577debc7-1f51-484e-93a0-a4d1e0d755e4", "AQAAAAIAAYagAAAAEMNG78AI0MQ2OQDvPqaZ5ngrlQqVeGLVsoqhxDPirPJqYfN1y88lF0FmjgWlCHHvfA==", "73bde1a6-1edb-46e1-a234-b1944001304e" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2bda635a-eaf4-4585-976a-45907a7caf20", "AQAAAAIAAYagAAAAEPqjcEYKqGdbyP/Fqcg6MKJX7Z6D44frdt1sMhHibmZ+fZj08KfihsSUB/CHgyBeKw==", "0d3ee7b4-575f-45d6-8866-79e934eccba8" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf64ab82-3247-4cb0-953b-c16d9ec13ead", "AQAAAAIAAYagAAAAEKd/I1ar7UJfP7Vb64J99gx7n2DrNNpeMdYFHRxIvIdvOyX/+Rqn/P8cPZ5SEpweeg==", "73fcf1fe-91c5-4e14-b25d-56726b672e61" });
        }
    }
}
