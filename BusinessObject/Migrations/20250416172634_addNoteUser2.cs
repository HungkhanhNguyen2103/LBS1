using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addNoteUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChapterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<int>(type: "int", nullable: false),
                    End = table.Column<int>(type: "int", nullable: false),
                    SelectedText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteUser", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteUser");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "852f47fd-3944-4249-b4bf-a33ed044e4f9", "AQAAAAIAAYagAAAAENWPJOdd4WdbN2yfrag4ejOXJEbNojEhECZDVNFDdL1uRzabccIT7irn4N6ssU2GQw==", "d7073915-e791-4fe3-a620-2738fd1cb6bd" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f39674e8-498f-406e-ad90-f503d254718b", "AQAAAAIAAYagAAAAEDYrx8UdhrAU1toYUMEtr99dPxslBEoXATqStLlPkp2rp9DmOqiteKKomDaWfxGeYQ==", "ab973c95-3729-4f97-a7b5-fbb9684c73c6" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eddc21d3-7911-4c88-aa10-71ce209843a3", "AQAAAAIAAYagAAAAEB3owuPJWk+BSxuv1D0ipoeQDqTgEwAFjmK+oeav3Xsb6uD4Snho04KEC0UUhy4iJg==", "f9d6e667-1c75-470a-94ca-52999b2f47f9" });
        }
    }
}
