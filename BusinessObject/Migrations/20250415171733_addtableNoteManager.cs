using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addtableNoteManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteManager", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteManager");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c76d968c-8684-4bb1-80a4-0c04e78353a4", "AQAAAAIAAYagAAAAEMlccEiXUeR29sKcbAMiiL+UY8NZN3yfs1dOiPMu/EUtroEnptai8daKfVuJVRNAww==", "12d861a0-a050-4d9d-99a3-01a6d86d3a22" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58cc3b32-e6dc-4861-b3f8-4133adc054c7", "AQAAAAIAAYagAAAAEGz/czn2lEvH7TkqXBCOP0ewuXA7WQ9cQrZxPpsfLO6S3Tt+w9TmKTJ8pmmo8LbhOA==", "13688f14-e535-4590-81e9-d684f3c2ae39" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cd33719-0b6e-4d70-a3c1-1787224edc62", "AQAAAAIAAYagAAAAEOrV2N1H7bFhQjQA7U6ozGGzL2+fYCGQztwW+JfvMFCy5WabTwuCITbvbTUbDTJ7mQ==", "d7438b74-6e2c-47fd-ab5d-b721e2794a9d" });
        }
    }
}
