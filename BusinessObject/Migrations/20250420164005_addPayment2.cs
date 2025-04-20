using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addPayment2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90261240-7ebf-4ea4-838f-5f8a221f7bfd", "AQAAAAIAAYagAAAAEKBjqhIAzl2PQRvtQMf3DduJdKRckp/ax29pRm5plri/FA2S7Q154Dyg53GiAnwaIg==", "1034774f-eac6-4e22-b997-8504ed9d0afa" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "325f4fc0-831a-4635-bd0c-556e4b34d330", "AQAAAAIAAYagAAAAEAPGR/24eAkOXETeVHBKCOCdIFWQmjxeXWpWsUCj6J7o9sW093AckFbiDCZMmy6RoA==", "89da3968-5de1-431b-97cf-6c29c4af231a" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d68d971-ebf4-444b-9fa2-6639307ac7c8", "AQAAAAIAAYagAAAAEMuBIcVeU8KUE1qag1HAZuLoUJHIhm+Hadw8ttYwpziG+72vwwp5CLQMIPQb9uAwzg==", "5223b79f-481d-4c29-9db5-5bf6d6afca4e" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTranscationBook_BookId",
                table: "UserTranscationBook",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTranscationBook_Book_BookId",
                table: "UserTranscationBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTranscationBook_Book_BookId",
                table: "UserTranscationBook");

            migrationBuilder.DropIndex(
                name: "IX_UserTranscationBook_BookId",
                table: "UserTranscationBook");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "756c311b-7ad8-4f8c-8ee7-b38daa8f9bb9", "AQAAAAIAAYagAAAAECX3+P6fF2v+hpDsUl8dpPijZ9Z/cBUXZqCHxoXSxwJ1jVO4chfCoUBbUUeSkW6rog==", "415879b1-0d84-41f2-bde2-8b8a991e48e0" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd8e2c8c-5692-4952-b937-f9d8619c9e73", "AQAAAAIAAYagAAAAEIRULcQG/3pLW9yWvGIY4bHfuekhPe7YDHdXnAWrZf3aS+v5VLd5Y2+xue3wuigR+w==", "1232581e-125f-4c20-b68c-1596ad7d7f8f" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e953219-6f41-4e62-9807-193386626ea6", "AQAAAAIAAYagAAAAEDm43DwsR//eK0/CenGRm2HGuM7SHKNYxg5dWm8PbW1P8RpGc5OGLx8jPymwX3Y6qA==", "4e859926-30eb-4563-9589-8463430fd937" });
        }
    }
}
