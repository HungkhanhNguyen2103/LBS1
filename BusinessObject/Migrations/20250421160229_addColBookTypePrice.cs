using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addColBookTypePrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookTypePrice",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4975fd10-af12-4ac6-8783-8305a717ebd5", "AQAAAAIAAYagAAAAEGdHZXNqCBTJOAVepcK2HsMxZBlkYuyTd99IsrSF4Rh6Otds6F86en0hsm5UbMs0zw==", "5f3936de-f8ac-4c6a-85e8-86dbe5df2aac" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "635a10e3-fddf-4059-8644-997f3d5d2b51", "AQAAAAIAAYagAAAAECrmzG3chbeoX8E3e7zN2qsNEn2cq+KoaF+nduXbSNCaJifFFY86t3RvmDjjVT9pfw==", "8435e15d-36d9-4a75-8061-c1fec6e6b617" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbba813a-e9fe-477d-9687-251e9d258cba", "AQAAAAIAAYagAAAAENzx1LI8Oc2nSNwRQu45tEY4x4MxhiLI85zjbgGtq3ZNaL7fSrRh6oKdBWY8bPrZXQ==", "02337d03-f18c-4d8a-977e-9c16a9fe1bbd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookTypePrice",
                table: "Book");

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
    }
}
