using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addNullConspectus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Conspectus",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Conspectus",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7220e2bc-2bb5-43e1-9c0c-7c14368c3ff8", "AQAAAAIAAYagAAAAEF0S4AF67JaeUbeyTsXveLfm2QOf5MTZO/5Oo7Q7YNVy8vPFrzT0idcCw6pBzFhAAA==", "fca73f27-7c81-428c-a897-17764efc01af" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc6bc67a-88cc-443a-ac8e-c25ceb3e2a82", "AQAAAAIAAYagAAAAEJi8rB0J92zu91brXr1NcQNIoST/x01AIiC20crSW+9uAzKwniLILkKolh96GyD7tg==", "75d8424c-ba06-4535-a4c2-8bd3cd70994c" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d2741bb-83ac-46f5-bc9f-f39e34c64dfc", "AQAAAAIAAYagAAAAEAevM2Vk0VDFNiA7cllugOKmqEEZ7KmHtTvvlcvHKg9795z+8kdbG2K9af8ZkO9B7Q==", "c7efb636-66d6-47fc-be7c-4fdcc4803927" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Conspectus",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Conspectus",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

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
        }
    }
}
