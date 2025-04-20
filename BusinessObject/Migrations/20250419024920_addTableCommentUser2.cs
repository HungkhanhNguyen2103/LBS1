using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class addTableCommentUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "CommentUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "CommentUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29d2ddda-7a5e-42e1-8927-efc52bc38396", "AQAAAAIAAYagAAAAEOeMYgTzyAtNwJeF0j1L9l/CnYgVYsbPRKCNc5NK2DAEWo0qQpQCwt0EU0uRMhqZwQ==", "58d1b12f-4d79-4aa6-8b36-059c6cd091b2" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8aa0fa00-cff3-4f8e-98d2-e70fb565a8dd", "AQAAAAIAAYagAAAAENWlrs8qjrwO0W0j3npUPpY3vG4pDso2EjL2uw28hBXrAf2waAw6j1WkPb/KuJI1kw==", "7ca0ef99-0a91-4dc2-a4d7-fdc4646898ab" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da004515-5211-4fef-ada1-15d5f60b1524", "AQAAAAIAAYagAAAAEPNPNeVBghve9yS9YvKoiZE+OG8ZjEZUd7j6MzsqtN0WaTpWfROmn9NPRqU8DFnYPg==", "971fcec7-5369-4a22-a652-036c598bc143" });
        }
    }
}
