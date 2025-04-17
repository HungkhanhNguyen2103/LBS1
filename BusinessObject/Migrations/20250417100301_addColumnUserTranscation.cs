using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addColumnUserTranscation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "UserTranscation",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "UserTranscation");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fecf40bf-bc3c-4d95-8db8-dcb14c98dd12", "AQAAAAIAAYagAAAAEADjci/LY9c4PClf81sLnvgXPOhAxvRcWN7q2WGJh+yiKbt6PY9eMbns57etA+qawQ==", "b8988e66-f435-4663-9104-fdafedef9ccf" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b83bf299-c5d3-41c4-a3f2-77b11d6e2a96", "AQAAAAIAAYagAAAAEEFlBB355OTgV7ARGD/ty9/msF1rKCuEpxOMI4drkfqRo0qaoWC/KgVo+zgH9qXA0w==", "e6bfe8c0-5972-4651-bcec-fdfc3eef03a6" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0685159e-ae8b-41f1-a90d-e288b74981d8", "AQAAAAIAAYagAAAAEE2K18KNEA1MIOX7NQrfLSdWg83a3O2JCPiHERvuZ+YrMnaoA8PAeyNaRxZrBLuF6Q==", "ca1d2c73-4be9-46dc-aafb-a53b7cec6ed6" });
        }
    }
}
