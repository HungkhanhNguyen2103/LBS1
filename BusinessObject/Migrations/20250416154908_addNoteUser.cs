using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addNoteUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa1d777d-e3bb-4b31-b371-77525e5f3d9f", "AQAAAAIAAYagAAAAEHP5TANKHs9W7F1zLs6iygnbzghuBoXh9G4ZGLTi40yDXZRVFLOx/FOw6GNCFXHsTQ==", "5e0ccb98-e8dd-4b73-984f-115e36d20c1e" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2156d2b5-dd90-423e-a906-08af3a9080fa", "AQAAAAIAAYagAAAAEMkF6B2svI4POw/aeV4b3923Uytb13KZctBNJRJw3FWkcQ1145J26nxqb61G+IknVA==", "44ebd265-3577-4056-b0d9-6690c3546f5e" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00e45f5d-3f23-42e7-8aa9-63e091c0defb", "AQAAAAIAAYagAAAAENzYyncbcgbb/TL6YqLJuqlN5NoVkEPhF+p+yupxasCVgv8XBj+4O4+5MP+NvohU5w==", "26754c57-54dc-4e29-9f7d-7118f288a102" });
        }
    }
}
