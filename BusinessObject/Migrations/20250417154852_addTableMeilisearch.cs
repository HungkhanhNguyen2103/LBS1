using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addTableMeilisearch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeilisearchLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeilisearchLogs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25262bfd-2474-49b4-a88d-07fed36745dc", "AQAAAAIAAYagAAAAEMYud5P3Uj5LxdtPmfnne2cqgdM+wszDEqd6EzzVn/Cph5uSmjUfoUmPkTLNDKzO7Q==", "a30d2346-7e41-4b84-8bb5-117a68c384b9" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21b5157f-46f7-4526-8125-b96b2985a16d", "AQAAAAIAAYagAAAAEKdU1G+hr/K0LrpOj9qSLPLJ1ORtgHSEgL8OnrtDZuDcUDbFBXE+OY5obj4Y8V+apg==", "6746e978-febb-4518-836b-420b53120c7a" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa5258c0-a174-438c-961a-6e21939aa4d0", "AQAAAAIAAYagAAAAEPg/t4UCM98MCJvEH37/8XHKct7AfIEuhAgp4zFB9tdaYvUEUzlksST4ruOvzwbTRA==", "7d57e3c2-4e6d-4a92-983b-fa88891bec47" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeilisearchLogs");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10b9dfeb-47a1-425c-9912-287991f3d1a1", "AQAAAAIAAYagAAAAENuo2COZ8bik7lYfo1FWdSXK0PiK1IDe6K1LbvLWYy/3ncZ8ub4rTZnwkY53ouEZdA==", "03f3bb44-c212-43e7-952f-a20607edaf46" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7675d59-3d85-48a0-874a-09ced30ed6e6", "AQAAAAIAAYagAAAAEMe7L+Qq9S2QsGurQCVEJEXhpRqxLLQimtFi6IyWMtImvHKnsSzd8yxkiup2bzwqAw==", "743626e3-0d91-491c-9557-f8b18ae94888" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d622d414-c37b-48ee-99b4-50f7c5671906", "AQAAAAIAAYagAAAAEMISiEgybg41MFRQG+grO58uretMAAcngoMBubyMRzMeBGZ2Bt/pykLy99q42MjWbQ==", "b409e5e6-ea13-4cd6-af09-45144ca33997" });
        }
    }
}
