using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class updateViewtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserBookView");

            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "UserBookView",
                newName: "EndDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "UserBookView",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1f23960-7ac2-4143-ae2f-d288d0bc98dc", "AQAAAAIAAYagAAAAEPtDOjAXCcWsGY8x18C5d+rEfPJbAmoLq9Vh6IJzJK9vkf7P6kZOj5JlDL2Tl5ySUQ==", "a63e359a-6c72-4658-b7d3-23aeac3263e7" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0762549d-d29e-4b62-888c-18976b49f404", "AQAAAAIAAYagAAAAEAUtvFbWrnfQnHqZyAkn54507xM54graKfL37E//v8FyTeO8VyhDLd7sLbEtxtIkmw==", "744fcd24-ab06-4322-b395-aff3d3d2bf99" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5112d2b-6a69-4757-bf0f-99f58620eb7c", "AQAAAAIAAYagAAAAEGWVMgBquFowj2uo/q+atDjJIk7rBtG2FBGcxAt/jjmGHXy5UO+i2C1ebO6PhrzzUw==", "ac50f31b-2f24-4804-b822-aaa256cace2f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "UserBookView");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "UserBookView",
                newName: "ModifyDate");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UserBookView",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213dd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "509d167b-ef94-443c-983f-30cb2ac7b285", "AQAAAAIAAYagAAAAEOZwi6VqOGYEjmzs/EEyi0jVCdwcI5HnD8oI9gbvyrXlJgi+TYWpc+KIGqeWqGI9Kw==", "7aae4a72-1c5b-414b-8e22-e4f973765f38" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eed213ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c155d00-752e-4838-b323-a4fa5f2ab3bf", "AQAAAAIAAYagAAAAEMNIKRohLZIyNqOPur57Fp45VbtwfY5MM8wXbATp9DIEchRCL6zElB10t2auRwRqfA==", "f24b5934-b208-4f83-b2c8-94ff7e8d7ba2" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "7d5002bd-f22f-4c7c-bce1-3d22eff012ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fbc2b31-8edf-40e6-8add-fe69c4900da7", "AQAAAAIAAYagAAAAEIFaeX0lISKsFJrPfMM6NhXQbKTXToDcOzji+mub/lluYpvSmIKS6ZqEWJvGgbEn4g==", "8da3decf-a59f-40a6-94c7-b5a9084f42de" });
        }
    }
}
