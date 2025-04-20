using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addColBookId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "NoteUser",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "NoteUser");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b020832-9deb-4b8e-b814-0f81f966159b", "AQAAAAIAAYagAAAAELgShEa3lZ89/Q6KYRtDFTqTbyHo+Q8z1yQ9NE8+R/HhhPflP1/xY6fwdAguTUgSmQ==", "96bea1ab-dd30-4edd-9d6d-1bec003e4e62" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "952a508e-3ff4-41ab-afdb-feab4cea42d3", "AQAAAAIAAYagAAAAELwVG57mjVUWKCMmxNp49E4odUvhM3YZcG3Y1zmpK9oWaqk6UKoA59bccuYY+ompEg==", "3db44c25-731a-4ce8-8f1d-fc7af08f3af6" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21187d89-74f0-450a-bbc6-ded805d1389f", "AQAAAAIAAYagAAAAEA7hg1JUEWXJcj3QrRA2E/h5nsb/v9cEJE+B6bAS47JK84fwbHQExtsj2vK3UCwrRw==", "ba83fe14-301a-4979-835d-5b6e2f246733" });
        }
    }
}
