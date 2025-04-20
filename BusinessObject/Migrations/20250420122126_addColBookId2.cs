using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addColBookId2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ChapterId",
                table: "UserTranscationBook",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "UserTranscationBook",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8dfb821-2edd-4d63-82e8-768491366601", "AQAAAAIAAYagAAAAEI0y3/WoNWC88u3+fa8N4VyvraL3gzVpeXTE7Szj5K0gygbdXsrS3qKvXVxDJ943XA==", "b4f789a0-1dd4-4e9f-8068-a8b6446fb6ba" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3d814c1-e0da-4621-9563-4f2206d3e0dc", "AQAAAAIAAYagAAAAEGXLR0rWKOv/orIhLYm30q8M4MmKVy6+ipVjq9PcCb0R5qt09XWJ7oAQV7//48IliQ==", "920a30bf-04f3-4745-84af-64470586bfba" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b96090b-b04d-47bc-932f-f04c9352854a", "AQAAAAIAAYagAAAAEGsNpv/zAlhbcPrfjWO5dvQ6qA7xQp9zDDt5jJx7YzlOwF+Zu0MxkUvKQuJj2HfZUw==", "0c5e2b1b-d84f-4015-a164-e948077d20f7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "UserTranscationBook");

            migrationBuilder.AlterColumn<string>(
                name: "ChapterId",
                table: "UserTranscationBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a481627a-e7a4-4aa9-8f98-475dd4f18151", "AQAAAAIAAYagAAAAEAPBj9f6IRVy8qrMwid6LVCSopMmNPugSAmXv1xk/ZnNEMdgbJtVtcCHak3XrXeSNw==", "aae226f3-0304-446b-a900-91ddb5ae52ee" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b13d876-0023-47dd-a7d2-bb39640d405c", "AQAAAAIAAYagAAAAECkJe7/5zVg3ohkgPyDiAbXO3VDhbIOtHKK1jh77NHIfoDGcQlp2tMjd03xyaAVOJg==", "852ed4b6-5302-41e5-99d0-31187d5589bb" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "820b9107-85fd-4168-9ccd-3b8dbbc61914", "AQAAAAIAAYagAAAAEAPysURictzuECg/GdmuAPMG+CpVEGFoGM/MzWJ+R1+T1grk7AMyuRGsPI1oasHGNQ==", "5c17fe65-cf00-4478-af38-d9bff0f5c9ac" });
        }
    }
}
